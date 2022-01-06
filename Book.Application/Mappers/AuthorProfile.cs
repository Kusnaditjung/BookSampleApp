using AutoMapper;

namespace Book.Application.Mappers
{
	public class AuthorProfile : Profile
	{
		public AuthorProfile()
		{
			CreateMap<Domain.Author, Dto.AuthorDto>()
				.ReverseMap();
		}
	}
}
