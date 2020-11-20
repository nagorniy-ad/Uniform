using AutoMapper;
using System;
using System.Threading.Tasks;
using Uniform.Core.Dtos;
using Uniform.Core.Entities;
using Uniform.Core.Repositories;
using Uniform.Core.Services;

namespace Uniform.Services
{
    public class FormService : IFormService
    {
        private readonly IMapper _mapper = AutoMapperFactory.Create();
        private readonly IUnitOfWork _unit;

        public FormService(IUnitOfWork unit)
        {
            _unit = unit ?? throw new ArgumentNullException(nameof(unit));
        }

        public async Task SaveFormAsync(SaveFormInput input)
        {
            var form = _mapper.Map<Form>(input);
            await _unit.Forms.CreateAsync(form);
            await _unit.SaveChangesAsync();
        }

        public async Task<SearchFormOutput> SearchFormAsync(SearchFormInput input)
        {
            var result = await _unit.Forms.FindAsync(input.Request);
            return _mapper.Map<SearchFormOutput>(result);
        }
    }
}
