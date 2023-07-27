using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Application.Interface
{
    public interface IDeleteToken
    {
        Task<bool> DeleteAsync(string userid);
    }
}
