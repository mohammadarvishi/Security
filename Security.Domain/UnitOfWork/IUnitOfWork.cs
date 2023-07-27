using Security.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Commit();
        TokenDBContext Context { get; }
        ITokenRepository TokenRepository { get; }
    }
}
