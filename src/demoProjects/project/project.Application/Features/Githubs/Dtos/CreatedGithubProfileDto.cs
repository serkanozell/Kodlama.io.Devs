using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Githubs.Dtos
{
    public class CreatedGithubProfileDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RepositoryName { get; set; }
        public string Url { get; set; }
    }
}
