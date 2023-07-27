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
    public class CreateToken:ICreateToken
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public CreateToken(IUnitOfWork UW, IJwtService jwtService = null)
        {
            _unitOfWork = UW;
            _jwtService = jwtService;
        }
        public async Task<string> CreatAsync(string userid)
        {
            var user = await _unitOfWork.TokenRepository.FindUserByIdAsync(userid);
            if (user == null)
            {
                var token = "Bearer " + _jwtService.GenerateToken(userid);
                var result = await _unitOfWork.TokenRepository.CreateAsync(userid, token);
                return token;
            }
            return null;
        }
    }
}
