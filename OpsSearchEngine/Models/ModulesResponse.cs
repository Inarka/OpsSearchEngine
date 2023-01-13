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
		public Dictionary<string, ModuleResponse> Modules { get; set; } = new Dictionary<string, ModuleResponse>();
	}

	public class ModuleResponse
	{
		public bool IsEndo { get; set; }
		public string ModulGruppe { get; set; }
		public string Name { get; set; }

		//public string InclICD { get; set; }
		public int SurveilanceTime { get; set; }
		public int SchnittNahtZeit { get; set; }
		public int REFASA { get; set; }
		public int REFWKR { get; set; }
		public string WKL { get; set; }

		//public int? StartAlter { get; set; }
		//public int? BisAlter { get; set; }
	}
}
