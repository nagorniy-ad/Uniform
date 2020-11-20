using System.Threading.Tasks;
using Uniform.Core.Dtos;

namespace Uniform.Core.Services
{
    public interface IFormService
    {
        Task SaveFormAsync(SaveFormInput input);
        Task<SearchFormOutput> SearchFormAsync(SearchFormInput input);
    }
}
