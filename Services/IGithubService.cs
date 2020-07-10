using PollyDemo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollyDemo.Services
{
    public interface IGithubService
    {
        Task<GithubUser> GetUserByUsernameAsync(string username);

        Task<List<GithubUser>> GetUsersFromOrgAsync(string orgName);
    }
}
