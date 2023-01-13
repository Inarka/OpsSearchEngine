using AutoMapper;
using OpsSearchEngine.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
	public class MappingTests
	{

		[Fact]
		public void ResponseMappingProfile_Configuration_ShouldBeValid()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<ResponseMappingProfile>());

			config.AssertConfigurationIsValid();
		}
	}
}
