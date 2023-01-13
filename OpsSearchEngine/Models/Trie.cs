
using OpsSearchEngine.Models.XML;
using System.Collections.Generic;

namespace OpsSearchEngine.Models
{
    public class Node
    {
        public Dictionary<char, Node> Links { get; set; } = new Dictionary<char, Node>();
        public bool Terminal { get; set; }
        public List<Modul> Modules { get; set; } = new List<Modul>();
        public HashSet<string> Excludes { get; set; } = new HashSet<string> ();
        public HashSet<string> Includes { get; set; } = new HashSet<string> ();
	}
}
