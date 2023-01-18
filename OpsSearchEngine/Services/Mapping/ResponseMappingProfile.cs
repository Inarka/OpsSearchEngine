using AutoMapper;
using OpsSearchEngine.Models;
using OpsSearchEngine.Models.XML;

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
