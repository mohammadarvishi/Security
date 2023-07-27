using Security.Application.Interface;
using Security.Domain.Entity;
using Security.Domain.UnitOfWork;
using Security.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Application.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IJwtService _jwtService;
        private readonly IUnitOfWork _unitOfWork;

        public TokenHandler(IJwtService jwtService, IUnitOfWork unitOfWork)
        {
            this._jwtService = jwtService;
            this._unitOfWork = unitOfWork;
        }
        public async Task<string> Token(string UserId)
        {
            var token = "Bearer " + _jwtService.GenerateToken(UserId);
            var user = await _unitOfWork.TokenRepository.FindUserByIdAsync(UserId);
            if (user == null)
            {
                var resuit = await _unitOfWork.TokenRepository.CreateAsync(UserId,token);
            }
            else
            {
                var result = await _unitOfWork.TokenRepository.UpdateToken(UserId, token);
            }
            return token;
        }
    }
}
