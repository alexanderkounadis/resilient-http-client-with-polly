using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PollyDemo.Contracts;
using PollyDemo.Services;

namespace PollyDemo.Controllers
{
    [ApiController]
    public class GithubController : ControllerBase
    {
        private readonly IGithubService _githubService;

        
        public GithubController(IGithubService githubService)
        {
            _githubService = githubService;
        }

        [HttpGet("users/{username}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            GithubUser user = await _githubService.GetUserByUsernameAsync(userName);
            return user != null ? (IActionResult)Ok(user) : NotFound();
        }

        [HttpGet("orgs/{orgName}")]
        public async Task<IActionResult> GetUsersInOrg(string orgName)
        {
            List<GithubUser> users = await _githubService.GetUsersFromOrgAsync(orgName);
            return users != null ? (IActionResult)Ok(users) : NotFound();
        }
    }
}
