using OpsSearchEngine.Interfaces;
using OpsSearchEngine.Models;
using OpsSearchEngine.Models.XML;
using System.Collections.Generic;
using System.Linq;

namespace OpsSearchEngine.Services
{
	public class Trie : ITrie
	{
		public Node Build(Project project)
		{
			var root = new Node();

			foreach (var module in project.Module.Moduls)
			{
				foreach (var trigger in module.Triggers)
				{
					Node current = root;

					for (int i = 0; i <= trigger.OPS.Length - 1; i++)
					{
						var symbol = trigger.OPS[i];

						if (symbol == '_' && i == trigger.OPS.Length - 1)
						{
							break;
						}

						var nextNode = current.Links.ContainsKey(symbol) ? current.Links[symbol] : null;

						if (nextNode == null)
						{
							var node = new Node();

							current.Links.Add(symbol, node);
						}

						current = current.Links[symbol];
					}

					current.ModuleInclExcls.Add(new ModuleInclExcl
					{
						ModulName = module.Name,
						Includes = trigger.Incl?.Split(";").ToList(),
						Excludes = trigger.Excl?.Split(";").ToList()
					});

					current.Terminal = true;
				}
			}

			return root;
		}
		public Node FindNode(Node root, string opsCode)
		{
			Node result = null;

			int patternIndex = 0;
			Node patternNode = null;

			for (int i = 0; i < opsCode.Length; i++)
			{
				var symbol = opsCode[i];
				
				if (root.Links.ContainsKey(symbol))
				{
					if (root.Links.ContainsKey('_'))
					{
						patternIndex = i;
						patternNode = root.Links['_'];
					}

					root = root.Links[symbol];

					if (root.Terminal)
					{
						result = root;
						break;
					}

					continue;
				}

				else if (root.Links.ContainsKey('_'))
				{
					root = root.Links['_'];
					continue;
				}

				else
				{
					result = null;
				}
			}

			if (result == null && patternNode != null)
			{
				for (int i = patternIndex + 1; i < opsCode.Length; i++)
				{
					var symbol = opsCode[i];

					if (patternNode.Links.ContainsKey(symbol))
					{
						patternNode = patternNode.Links[symbol];

						if (patternNode.Terminal)
						{
							result = patternNode;
							break;
						}

						continue;
					}
				}
			}

			return result;
		}
	}
}
