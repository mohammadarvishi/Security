using Security.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        public TokenDBContext Context { get; }
        private ITokenRepository _ITokenRepository;
        public UnitOfWork(TokenDBContext Contex)
        {
            Context = Contex;
        }

        public ITokenRepository TokenRepository
        {
            get
            {
                if (_ITokenRepository == null)
                {
                    _ITokenRepository = new TokenRepository(this);
                }

                return _ITokenRepository;
            }
        }

        public async Task Commit()
        {
            await Context.SaveChangesAsync();
        }
    }
}
