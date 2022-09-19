using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Githubs.Commands.DeleteGithubProfile
{
    public class DeleteGithubProfileCommandValidator : AbstractValidator<DeleteGithubProfileCommand>
    {
        public DeleteGithubProfileCommandValidator()
        {
            RuleFor(g => g.Id).NotEmpty();
        }
    }
}
