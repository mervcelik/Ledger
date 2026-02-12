using Application.Features.Finance.CurrentAccounts.Constans;
using Application.Repositories.Finance;
using Application.Services.Localization;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Application.Features.Finance.CurrentAccounts.Rules;

public class CurrentAccountBusinessRules
{
    ICurrentAccountRepository _currentAccountRepository;
    public CurrentAccountBusinessRules(ICurrentAccountRepository currentAccountRepository)
    {
        _currentAccountRepository = currentAccountRepository;
    }

    public async Task CurrentAccountNameCanNotBeDuplicatedWhenInserted(string name, int companyId)
    {
        var result = await _currentAccountRepository.GetListAsync(c => c.Name == name && c.CompanyId == companyId);
        if (result.Items.Any())
        {
            throw new Exception(LH.Get(CurrentAccountMessages.CANameCanNotBeDuplicated));
        }
    }
}
