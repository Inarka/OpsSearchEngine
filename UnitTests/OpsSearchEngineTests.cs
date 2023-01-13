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
		private readonly IMapper _mapper;

		public OpsSearchEngineTests()
		{
			var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new ResponseMappingProfile()));

			_mapper = new Mapper(configuration);
		}
		 

		[Fact]
		public async Task FindModules_IfModuleExistsAndIsEndo_ShouldReturnCorrectModule()
		{
			// Arrange

			var options = Options.Create(new OpsOptions() { FilePath = @"..\..\..\..\Files\OPKISS_DEF_2022_neu.xml" });

			var opsSearchEngine = new OpsSearchEngineService(new XmlStringReader(options), new XmlFileDeserializer<Project>(), new Trie(), _mapper);

			var inputOpsList = new List<string> { "5-324.62", "5-874.2" };

			// Act
			var modules = await opsSearchEngine.FindModules(new OpsSearchEngine.Models.OpsRequest() { OpsCodes = inputOpsList });

			// Assert
			Assert.NotEmpty(modules.Modules);
			Assert.True(modules.Modules["5-324.62"].IsEndo);
			Assert.False(modules.Modules["5-874.2"].IsEndo);
		}
	}
}