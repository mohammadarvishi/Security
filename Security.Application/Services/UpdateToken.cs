using Security.Application.Interface;
using Security.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Application.Services
{
    public class UpdateToken : IUpdateToken
    {
        private readonly IJwtService _jwtService;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateToken(IJwtService jwtService, IUnitOfWork unitOfWork)
        {
            _jwtService = jwtService;
            _unitOfWork = unitOfWork;
        }
        public async Task<string> UpdateAsync(string userid)
        {
            var user = await _unitOfWork.TokenRepository.FindUserByIdAsync(userid);
            if (user != null)
            {
                var token = "Bearer " + _jwtService.GenerateToken(userid);
                var result = await _unitOfWork.TokenRepository.UpdateToken(userid, token);
                return token;
            }
            return null;
        }
    }
}
