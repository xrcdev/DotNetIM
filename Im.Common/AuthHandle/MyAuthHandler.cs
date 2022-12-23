using Im.Common.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;
using IAuthenticationHandler = Microsoft.AspNetCore.Authentication.IAuthenticationHandler;

namespace system_webapi.Auth
{
    public class MyAuthHandler : IAuthenticationHandler
    {
        public const string SchemeName = "MyAuth";

        AuthenticationScheme _scheme;
        HttpContext _context;

        /// <summary>
        /// 认证处理
        /// </summary>
        public Task<AuthenticateResult> AuthenticateAsync()
        {
            var req = _context.Request.Headers;
            var json = req["userinfo"].FirstOrDefault();
            
            if (json==null|| json.Equals(""))
            { 
               return Task.FromResult(AuthenticateResult.Fail("未登陆"));
            }
             var tokenVo = JsonConvert.DeserializeObject<TokenVo>(json);
            //var tokenVo = new TokenVo() { id = 3, admin = "123" };
             var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                 new Claim(ClaimTypes.NameIdentifier, tokenVo.id.ToString()),
                 new Claim(ClaimTypes.Name, tokenVo.admin),
                 new Claim(ClaimTypes.Role, "admin"),
             }, "My_Auth");


            var principal = new ClaimsPrincipal(claimsIdentity);

            var ticket = new AuthenticationTicket(principal, _scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));

        }

        public Task ChallengeAsync(AuthenticationProperties? properties)
        {
            throw new NotImplementedException();
        }

        public Task ForbidAsync(AuthenticationProperties? properties)
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            _scheme = scheme;
            _context = context;
            return Task.CompletedTask;
        }
    }
}
