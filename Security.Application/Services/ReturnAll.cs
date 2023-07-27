using Security.Application.Interface;
using Security.Domain.UnitOfWork;
using Security.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Application.Services
{
    public class ReturnAll:IReturnAll
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReturnAll(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<TokenViewModel>> AllAsync()
        {
            var result = await _unitOfWork.TokenRepository.FindAllAsync();
            List<TokenViewModel> all=new List<TokenViewModel>();
            foreach (var item in result)
            {
                all.Add(new TokenViewModel
                {
                    UserId=item.UserId,
                    Token=item.Token
                });

            }
            return all;
        }
    }
}
