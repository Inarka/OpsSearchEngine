using AutoMapper;
using OpsSearchEngine.Models;
using OpsSearchEngine.Models.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpsSearchEngine.Services.Mapping
{
	public class ResponseMappingProfile : Profile
	{
		public ResponseMappingProfile()
		{
			CreateMap<Modul, ModuleResponse>().ForMember(dest => dest.IsEndo, opt => opt.Ignore());
		}
	}
}
