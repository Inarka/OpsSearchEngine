using OpsSearchEngine.Models;
using OpsSearchEngine.Models.XML;
using System.Collections.Generic;

namespace OpsSearchEngine.Interfaces
{
	public interface ITrie
	{
		public Node Build(Project project);
		public Node FindNode(Node root, string ops);
	}
}
