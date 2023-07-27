using Microsoft.EntityFrameworkCore;
using Security.Domain.Entity;
using Security.Domain.UnitOfWork;
using Security.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Repository
{
    public class TokenRepository:ITokenRepository
    {
        private readonly TokenDBContext _Context;
        private readonly IUnitOfWork _UW;
        public TokenRepository(IUnitOfWork UW)
        {
            _Context = UW.Context;
            _UW = UW;
        }
        public async Task<bool> UpdateToken(string id,string token)
        {
            var result = await _Context.Token.FirstOrDefaultAsync(m => m.UserId == id);
            if (result != null)
            {
                result.Token = token;
                await _UW.Commit();
                return true;
            }
                return false;
        }
        public async Task<TokenDB> FindUserByIdAsync(string Id)
        {
            var result = await _Context.Token.FirstOrDefaultAsync(m => m.UserId == Id);
            return result;
        }
        public async Task<IEnumerable<TokenDB>> FindAllAsync()
        {
            var result = await _Context.Token.ToListAsync();
            return result;
        }
        public async Task<bool> DeleteAsync(TokenDB tokenDB)
        {
            try
            {
                var user = _Context.Remove(tokenDB);
                await _UW.Commit();
                return true;
            }
            catch { return false; }
        }
        public async Task<bool> CreateAsync(string UserId,string Token)
        {
            try
            {
                TokenDB token = new()
                {
                    UserId = UserId,
                    Token = Token
                };
                await _Context.AddAsync(token);
                await _UW.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
