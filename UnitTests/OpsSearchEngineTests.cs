using AutoMapper;
using Microsoft.Extensions.Options;
using OpsSearchEngine.Interfaces;
using OpsSearchEngine.Models.Options;
using OpsSearchEngine.Models.XML;
using OpsSearchEngine.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using OpsSearchEngine.Services.Mapping;
using OpsSearchEngine.Services.Xml;

namespace UnitTests
{
	public class OpsSearchEngineTests
	{
		[Fact]
		public async Task FindModules_ShouldReturnCorrectModule()
		{
			// Arrange
			var myProfile = new ResponseMappingProfile();

			var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

			IMapper mapper = new Mapper(configuration);

			var options = Options.Create(new OpsOptions() { FilePath = @"C:\OPKISS_DEF_2022_neu.xml" });

			var opsSearchEngine = new OpsSearchEngineService(new XmlStringReader(options), new XmlFileDeserializer<Project>(), new Trie(), mapper);

			// Act
			await opsSearchEngine.FindModules(new OpsSearchEngine.Models.OpsRequest() { OpsCodes = new List<string> { "5-455.d5" } });
		
			// Assert
		}
	}
}