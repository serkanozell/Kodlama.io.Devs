using Core.Persistence.Paging;
using project.Application.Features.Githubs.Dtos;
using project.Application.Features.Languages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Githubs.Models
{
    public class GithubProfileListModel : BasePageableModel
    {
        public IList<GithubProfileListDto> Items { get; set; }
    }
}
