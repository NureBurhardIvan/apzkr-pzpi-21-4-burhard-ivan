using System;
using System.Collections.Generic;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using Application.Common.Interfaces.Services;
using Application.Common.Options;
using Application.User.DTOs.RequestDTOs;
using Application.User.DTOs.ResponseDTOs;
using Microsoft.Extensions.Options;
using System.Net;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Services
{
    public class CognitoAuthService : IAuthService
    {
        private readonly IAmazonCognitoIdentityProvider _identityProvider;
        private readonly IUserRepository _userRepository;
        private readonly CognitoUserPool _userPool;
        private readonly AwsOptions _awsOptions;

        public CognitoAuthService(IAmazonCognitoIdentityProvider identityProvider, CognitoUserPool userPool, IOptions<AwsOptions> awsOptions, IUserRepository userRepository)
        {
            _identityProvider = identityProvider;
            _userPool = userPool;
            _userRepository = userRepository;
            _awsOptions = awsOptions.Value;
        }

        public async Task<bool> ConfirmSignupAsync(SignUpConfirmationDto dto)
        {
            var signUpRequest = new ConfirmSignUpRequest
            {
                ClientId = _awsOptions.ClientId,
                ConfirmationCode = dto.Code,
                Username = dto.UserName
            };

            var response = await _identityProvider.ConfirmSignUpAsync(signUpRequest);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public async Task<AdminDeleteUserResponse> DeleteUserAsync(string username)
        {
            var deleteRequest = new AdminDeleteUserRequest
            {
                Username = username,
                UserPoolId = _awsOptions.UserPoolId
            };

            var response = await _identityProvider.AdminDeleteUserAsync(deleteRequest);
            return response;
        }

        public async Task<TokenDto> LoginAsync(AuthCredentialsDto credentials)
        {
            var user = new CognitoUser(credentials.UserName, _awsOptions.ClientId, _userPool, _identityProvider);
            var authRequest = new InitiateSrpAuthRequest
            {
                Password = credentials.Password
            };

            var authResponse = await user.StartWithSrpAuthAsync(authRequest);

            var expiresAt = DateTime.Now + TimeSpan.FromSeconds(authResponse.AuthenticationResult.ExpiresIn);
            var idToken = authResponse.AuthenticationResult.IdToken;
            var refreshToken = authResponse.AuthenticationResult.RefreshToken;

            var response = new TokenDto(idToken, refreshToken, expiresAt);

            return response;
        }

        public async Task<UserGotDto> RegisterAsync(RegisterUserDto registerDto)
        {
            var roleTitle = nameof(Role.User);
            var request = new SignUpRequest
            {
                Username = registerDto.UserName,
                ClientId = _awsOptions.ClientId,
                Password = registerDto.Password,
                UserAttributes = new List<AttributeType>
                    {
                        new()
                        {
                            Name = "email",
                            Value = registerDto.Email
                        },
                        new()
                        {
                            Name = "custom:role",
                            Value = roleTitle
                        }
                    },
            };

            var signUpResponse = await _identityProvider.SignUpAsync(request);

            var a = await _userRepository.Create(registerDto with { Id = new Guid(signUpResponse.UserSub) });
            return a;
        }
    }
}
