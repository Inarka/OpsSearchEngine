using Microsoft.Extensions.Options;
using OpsSearchEngine.Interfaces;
using OpsSearchEngine.Models.Options;
using System.IO;

namespace OpsSearchEngine.Services.Xml
{
    public class XmlStringReader : IXmlStringReader
    {
        private readonly OpsOptions _options;

        public XmlStringReader(IOptions<OpsOptions> options)
        {
            _options = options.Value;
        }

        public string ReadXml()
        {
            return File.ReadAllText(_options.FilePath);
        }
    }
}
