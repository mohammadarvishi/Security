using Security.Application.Interface;
using Security.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Application.Services
{
    public class DeleteToken:IDeleteToken
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteToken(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> DeleteAsync(string userid)
        {
            var user = await _unitOfWork.TokenRepository.FindUserByIdAsync(userid);
            if (user != null)
            {
                var result = await _unitOfWork.TokenRepository.DeleteAsync(user);
                if(result)
                return true;
            }
            return false;
        }
    }
}
