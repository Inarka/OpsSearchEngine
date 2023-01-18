using OpsSearchEngine.Models;

namespace OpsSearchEngine.Interfaces
{
	public interface IEngine
	{
		public ModulesResponse FindModules(PatientInfo patientInfo);
	}
}
