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

					current.Modules.Add(module);

					if (trigger.Excl != null)
					{
						current.Excludes.UnionWith(trigger.Excl.Split(";").ToList());
					}

					if (trigger.Incl != null)
					{
						current.Includes.UnionWith(trigger.Incl.Split(";").ToList());
					}

					current.Terminal = true;
				}
			}

			return root;
		}
		public Node FindNode(Node root, string opsCode)
		{
			for (int i = 0; i < opsCode.Length; i++)
			{
				var symbol = opsCode[i];

				//if (root.Terminal)
				//{
				//	result.Add(root);
				//	break;
				//}

				//else
				
				if (root.Links.ContainsKey(symbol))
				{
					root = root.Links[symbol];

					if (root.Terminal)
					{
						return root;
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
					return null;
				}
			}

			return null;
		}
	}
}
