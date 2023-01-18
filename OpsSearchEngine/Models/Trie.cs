using System.Collections.Generic;

namespace OpsSearchEngine.Models
{
    public class Node
    {
        public Dictionary<char, Node> Links { get; set; } = new Dictionary<char, Node>();
        public bool Terminal { get; set; }
        public List<ModuleInclExcl> ModuleInclExcls { get; set; } = new List<ModuleInclExcl>();
	}

    public class ModuleInclExcl
    {
        public string ModulName { get; set; }
		public List<string> Excludes { get; set; } = new List<string>();
		public List<string> Includes { get; set; } = new List<string>();
	}
}
