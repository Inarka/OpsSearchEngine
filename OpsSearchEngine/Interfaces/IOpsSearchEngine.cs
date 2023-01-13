using OpsSearchEngine.Models;
using System.Threading.Tasks;

namespace OpsSearchEngine.Interfaces
{
	public interface IOpsSearchEngine
	{
		public Task<ModulesResponse> FindModules(OpsRequest request);
	}
}
