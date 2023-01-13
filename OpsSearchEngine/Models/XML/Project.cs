using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OpsSearchEngine.Models.XML
{
	[XmlRoot(ElementName = "Project")]
	public class Project
	{
		[XmlElement(ElementName = "Module")]
		public Module Module { get; set; }
	}

	[XmlRoot(ElementName = "Module")]
	public class Module
	{
		[XmlElement(ElementName = "Modul")]
		public List<Modul> Moduls { get; set; }

		[XmlAttribute(AttributeName = "Year")]
		public int Year { get; set; }
	}

	[XmlRoot(ElementName = "Modul")]
	public class Modul
	{
		[XmlElement(ElementName = "Trigger")]
		public List<Trigger> Triggers { get; set; }

		[XmlAttribute(AttributeName = "ENDO_OPS")]
		public string ENDOOPS { get; set; }

		[XmlAttribute(AttributeName = "ModulGruppe")]
		public string ModulGruppe { get; set; }

		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "InclICD")]
		public string InclICD { get; set; }

		[XmlAttribute(AttributeName = "Description")]
		public string Description { get; set; }

		[XmlAttribute(AttributeName = "SurveilanceTime")]
		public int SurveilanceTime { get; set; }

		[XmlAttribute(AttributeName = "SchnittNahtZeit")]
		public int SchnittNahtZeit { get; set; }

		[XmlAttribute(AttributeName = "REF_ASA")]
		public int REFASA { get; set; }

		[XmlAttribute(AttributeName = "REF_WKR")]
		public int REFWKR { get; set; }

		[XmlAttribute(AttributeName = "WKL")]
		public string WKL { get; set; }

		[XmlAttribute(AttributeName = "REF_JJV")]
		public int REFJJV { get; set; }

		[XmlAttribute(AttributeName = "REF_JJB")]
		public int REFJJB { get; set; }

		[XmlAttribute(AttributeName = "REF_UDT")]
		public string REFUDT { get; set; }

		[XmlAttribute(AttributeName = "StartAlter")]
		public int StartAlter { get; set; }

		[XmlAttribute(AttributeName = "bisAlter")]
		public int BisAlter { get; set; }
	}

	[XmlRoot(ElementName = "Triggers")]
	public class Trigger
	{
		[XmlAttribute(AttributeName = "OPS")]
		public string OPS { get; set; }

		[XmlAttribute(AttributeName = "Incl")]
		public string Incl { get; set; }

		[XmlAttribute(AttributeName = "Excl")]
		public string Excl { get; set; }

		[XmlAttribute(AttributeName = "Text")]
		public string Text { get; set; }

		[XmlAttribute(AttributeName = "Hinweis")]
		public string Hinweis { get; set; }
	}
}
