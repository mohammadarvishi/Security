using Security.Domain.Entity;
using Security.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Repository
{
    public interface ITokenRepository
    {
        Task<bool> CreateAsync(string UserId, string Token);
        Task<TokenDB> FindUserByIdAsync(string Id);
        Task<bool> UpdateToken(string id, string token);
        Task<bool> DeleteAsync(TokenDB tokenDB);
        Task<IEnumerable<TokenDB>> FindAllAsync();
    }
}
