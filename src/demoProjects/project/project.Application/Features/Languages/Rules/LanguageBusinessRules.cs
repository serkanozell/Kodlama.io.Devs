﻿using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using project.Application.Services.Repositories;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(l => l.Name == name);
            if (result.Items.Any()) throw new BusinessException("Language name exists");
        }

        public void LanguageShouldExistWhenRequested(Language language)
        {
            if (language == null) throw new BusinessException("Requested language does not exist");
        }

        public async Task LanguageNameCanNotBeSameAsEntityModelWhenUpdated(string name)
        {
            var result = await _languageRepository.GetAsync(l => l.Name == name);
            if (result != null) throw new BusinessException("Language name and your request is same");
        }
    }
}
