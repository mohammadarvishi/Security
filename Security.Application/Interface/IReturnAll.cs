using Security.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Application.Interface
{
    public interface IReturnAll
    {
        Task<IEnumerable<TokenViewModel>> AllAsync();
    }
}
