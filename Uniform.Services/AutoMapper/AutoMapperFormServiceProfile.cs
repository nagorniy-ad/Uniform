using AutoMapper;
using System.Collections.Generic;
using Uniform.Core.Dtos;
using Uniform.Core.Entities;
using System.Linq;

namespace Uniform.Services
{
    internal class AutoMapperFormServiceProfile : Profile
    {
        public AutoMapperFormServiceProfile()
        {
            CreateMap<SaveFormInput, Form>();
            CreateMap<IReadOnlyList<Form>, SearchFormOutput>()
                .ForMember(m => m.Result, opt => opt.MapFrom(s => s.Select(f => f.Json).ToList()));
        }
    }
}
