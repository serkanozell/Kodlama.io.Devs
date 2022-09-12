using Core.Persistence.Paging;
using project.Application.Features.Languages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Languages.Models
{
    public class LanguageListModel : BasePageableModel
    {
        public IList<LanguageListDto> Items { get; set; }
    }
}
