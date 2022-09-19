using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Domain.Entities
{
    public class GithubProfile : Entity
    {
        public int UserId { get; set; }
        public string RepositoryName { get; set; }
        public string Url { get; set; }

        public GithubProfile()
        {
        }

        public GithubProfile(int id, int userId, string repositoryName, string url)
        {
            Id = id;
            UserId = userId;
            RepositoryName = repositoryName;
            Url = url;
        }
    }
}
