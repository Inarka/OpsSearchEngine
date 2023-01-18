using System;
using System.Collections.Generic;

namespace OpsSearchEngine.Models
{
	public class PatientInfo
	{
		public List<string> OpsCodes { get; set; }
		public List<string> IcdCodes { get; set; }
		public int Age { get; set; }
		public DateTime Date { get; set; }
	}
}
