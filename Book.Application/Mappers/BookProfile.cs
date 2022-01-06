using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Application.Mappers
{
	public class BookProfile : Profile
	{
		public BookProfile()
		{
			CreateMap<Domain.Book, Dto.BookDto>()
				.ReverseMap();


			CreateMap<Domain.Address, Dto.AddressDto>()
				.ReverseMap();
		}

	}
}
