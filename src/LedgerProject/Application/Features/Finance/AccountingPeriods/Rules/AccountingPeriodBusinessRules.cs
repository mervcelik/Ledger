using Application.Features.Finance.AccountingPeriods.Constans;
using Application.Repositories.Finance;
using Application.Services.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.AccountingPeriods.Rules;

public class AccountingPeriodBusinessRules
{
    IAccountingPeriodRepository _accountingPeriodRepository;
    public AccountingPeriodBusinessRules(IAccountingPeriodRepository accountingPeriodRepository)
    {
        _accountingPeriodRepository = accountingPeriodRepository;
    }

    public async Task AccountingPeriodDateRangeMustNotOverlap(DateTime startDate, DateTime endDate, int companyId)
    {
        var overlappingPeriod = await _accountingPeriodRepository.GetAsync(ap =>
            ap.CompanyId == companyId &&
            ((startDate >= ap.StartDate && startDate <= ap.EndDate) ||
             (endDate >= ap.StartDate && endDate <= ap.EndDate) ||
             (startDate <= ap.StartDate && endDate >= ap.EndDate))
        );
        if (overlappingPeriod != null)
        {
            throw new Exception(LH.Get(AccountingPeriodMessages.APDateRangeMustNotOverlap));
        }
    }

    public async Task AccountingNameMustBeUniqueWhenCreating(string name, int companyId)
    {
        var existingPeriod = await _accountingPeriodRepository.GetAsync(ap => ap.Name == name && ap.CompanyId == companyId);
        if (existingPeriod != null)
        {
            throw new Exception(LH.Get(AccountingPeriodMessages.APNameNotUniqie));
        }
    }
    public async Task AccountingNameMustBeUniqueWhenUpdating(int Id, string name, int companyId)
    {
        var existingPeriod = await _accountingPeriodRepository.GetAsync(ap => ap.Id != Id && ap.Name == name && ap.CompanyId == companyId);
        if (existingPeriod != null)
        {
            throw new Exception(LH.Get(AccountingPeriodMessages.APNameNotUniqie));
        }
    }
    public async Task AccountingPeriodDateRangeMustNotOverlapUpdating(int Id, DateTime startDate, DateTime endDate, int companyId)
    {
        var overlappingPeriod = await _accountingPeriodRepository.GetAsync(ap => ap.Id != Id &&
            ap.CompanyId == companyId &&
            ((startDate >= ap.StartDate && startDate <= ap.EndDate) ||
             (endDate >= ap.StartDate && endDate <= ap.EndDate) ||
             (startDate <= ap.StartDate && endDate >= ap.EndDate))
        );
        if (overlappingPeriod != null)
        {
            throw new Exception(LH.Get(AccountingPeriodMessages.APDateRangeMustNotOverlap));
        }
    }
}
