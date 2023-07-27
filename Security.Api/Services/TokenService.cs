using Grpc.Core;
using Security.Api.Protos;
using Security.Application.Interface;

namespace Security.Api.Services
{
    public class TokenService: Token.TokenBase
    {
        private readonly ITokenHandler _createToken;

        public TokenService(ITokenHandler createToken)
        {
            this._createToken = createToken;
        }
        public async override Task<TokenResponse> CreateToken(TokenRequest request, ServerCallContext context)
        {
            var tokenResponse = new TokenResponse
            {
                Token =await _createToken.Token(request.Userid)
            };
            return await Task.FromResult(tokenResponse);
        }
    }
}
