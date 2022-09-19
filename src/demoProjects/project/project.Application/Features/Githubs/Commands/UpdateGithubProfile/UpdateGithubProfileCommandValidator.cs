using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Githubs.Commands.UpdateGithubProfile
{
    public class UpdateGithubProfileCommandValidator : AbstractValidator<UpdateGithubProfileCommand>
    {
        public UpdateGithubProfileCommandValidator()
        {
            RuleFor(g => g.Id).NotEmpty();
            RuleFor(g => g.RepositoryName).NotEmpty();
            RuleFor(g => g.Url).NotEmpty();
        }
    }
}
