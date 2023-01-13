using Microsoft.Extensions.Options;
using OpsSearchEngine.Interfaces;
using OpsSearchEngine.Models.Options;
using System.IO;
using System.Threading.Tasks;

namespace OpsSearchEngine.Services
{
	public class XmlStringReader : IXmlStringReader
	{
		private readonly OpsOptions _options;

		public XmlStringReader(IOptions<OpsOptions> options)
		{
			_options = options.Value;
		}

		public Task<string> ReadXmlAsync()
		{
			return File.ReadAllTextAsync(_options.FilePath);
		}
	}
}
