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
using OpsSearchEngine.Models;
using System.Linq;

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

			var inputOpsList = new List<string> { "5-324.62", "5-874.2", "5-470.1" };

			// Act
			var modules = await opsSearchEngine.FindModules(new OpsRequest() { Age = 25, OpsCodes = inputOpsList });

			// Assert
			Assert.NotEmpty(modules.Modules);
			Assert.True(modules.Modules["5-324.62"].FirstOrDefault(x => x.Name == "LOBE")!.IsEndo);
			Assert.False(modules.Modules["5-874.2"].FirstOrDefault(x => x.Name == "MAST")!.IsEndo);
			Assert.Equal(103, modules.Modules["5-470.1"].FirstOrDefault(x => x.Name == "APPE")!.SchnittNahtZeit);
			Assert.True(modules.Modules["5-470.1"].FirstOrDefault(x => x.Name == "APPE")!.IsEndo);
		}
	}
}