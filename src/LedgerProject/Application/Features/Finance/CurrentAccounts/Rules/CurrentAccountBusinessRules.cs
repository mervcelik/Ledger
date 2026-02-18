using Application.Features.Finance.CurrentAccounts.Constans;
using Application.Repositories.Corp;
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
    ICompanyRepository _companyRepository;

    public CurrentAccountBusinessRules(ICurrentAccountRepository currentAccountRepository, ICompanyRepository companyRepository)
    {
        _currentAccountRepository = currentAccountRepository;
        _companyRepository = companyRepository;
    }

    public async Task CurrentAccountNameCanNotBeDuplicatedWhenInserted(string name, int companyId)
    {
        var result = await _currentAccountRepository.GetListAsync(c => c.Name == name && c.CompanyId == companyId);
        if (result.Items.Any())
        {
            throw new Exception(LH.Get(CurrentAccountMessages.CANameCanNotBeDuplicated));
        }
    }

    public async Task CompanyMustExist(int companyId)
    {
        var company = await _companyRepository.GetAsync(c => c.Id == companyId);
        if (company == null)
        {
            throw new Exception(LH.Get(CurrentAccountMessages.CACompanyMustExist));
        }
    }

    public async Task TaxNumberMustBeUnique(string taxNumber, int companyId, int? currentAccountId = null)
    {
        var result = await _currentAccountRepository.GetListAsync(c => c.TaxNumber == taxNumber && c.CompanyId == companyId);
        
        if (currentAccountId.HasValue)
        {
            result.Items = result.Items.Where(c => c.Id != currentAccountId).ToList();
        }

        if (result.Items.Any())
        {
            throw new Exception(LH.Get(CurrentAccountMessages.CATaxNumberMustBeUnique));
        }
    }
}
