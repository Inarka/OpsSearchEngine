using OpsSearchEngine.Models;
using OpsSearchEngine.Models.XML;

namespace OpsSearchEngine.Interfaces
{
	public interface ITrie
	{
		public Node Build(Project project);
		public Node FindNode(Node root, string ops);
	}
}
