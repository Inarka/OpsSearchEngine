using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpsSearchEngine.Models
{
	public class ModulesResponse
	{
		public Dictionary<string, List<ModuleResponse>> Modules { get; set; } = new Dictionary<string, List<ModuleResponse>>();
	}

	public class ModuleResponse
	{
		public bool IsEndo { get; set; }
		public string ModulGruppe { get; set; }
		public string Name { get; set; }
		public int SurveilanceTime { get; set; }
		public int SchnittNahtZeit { get; set; }
		public int RefAsa { get; set; }
		public int RefWkr{ get; set; }
		public string Wkl { get; set; }
	}
}
