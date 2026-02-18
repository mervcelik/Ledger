using Application.Features.Finance.CurrentMovements.Constans;
using Application.Repositories.Corp;
using Application.Repositories.Finance;
using Application.Services.Localization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentMovements.Rules;

public class CurrentMovementBusinessRules
{
    private readonly ICurrentMovementRepository _currentMovementRepository;
    private readonly ICurrentAccountRepository _currentAccountRepository;
    private readonly IAccountingPeriodRepository _accountingPeriodRepository;
    private readonly IMovementTypeRepository _movementTypeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly ILocalizationService _localizationService;

    public CurrentMovementBusinessRules(
        ICurrentMovementRepository currentMovementRepository,
        ICurrentAccountRepository currentAccountRepository,
        IAccountingPeriodRepository accountingPeriodRepository,
        IMovementTypeRepository movementTypeRepository,
        ICompanyRepository companyRepository,
        ILocalizationService localizationService)
    {
        _currentMovementRepository = currentMovementRepository;
        _currentAccountRepository = currentAccountRepository;
        _accountingPeriodRepository = accountingPeriodRepository;
        _movementTypeRepository = movementTypeRepository;
        _companyRepository = companyRepository;
        _localizationService = localizationService;
    }

    public async Task CurrentAccountMustExist(int currentAccountId)
    {
        var account = await _currentAccountRepository.GetAsync(ca => ca.Id == currentAccountId);
        if (account == null)
        {
            throw new BusinessException(_localizationService.Get(CurrentMovementMessages.CurrentAccountMustExist));
        }
    }

    public async Task AccountingPeriodMustExist(int accountingPeriodId)
    {
        var period = await _accountingPeriodRepository.GetAsync(ap => ap.Id == accountingPeriodId);
        if (period == null)
        {
            throw new BusinessException(_localizationService.Get(CurrentMovementMessages.AccountingPeriodMustExist));
        }
    }

    public async Task AccountingPeriodMustNotBeClosed(int accountingPeriodId)
    {
        var period = await _accountingPeriodRepository.GetAsync(ap => ap.Id == accountingPeriodId);
        if (period != null && period.IsClosed)
        {
            throw new BusinessException(_localizationService.Get(CurrentMovementMessages.AccountingPeriodMustNotBeClosed));
        }
    }

    public async Task MovementTypeMustExist(int movementTypeId)
    {
        var movementType = await _movementTypeRepository.GetAsync(mt => mt.Id == movementTypeId);
        if (movementType == null)
        {
            throw new BusinessException(_localizationService.Get(CurrentMovementMessages.MovementTypeMustExist));
        }
    }

    public async Task CompanyMustExist(int companyId)
    {
        var company = await _companyRepository.GetAsync(c => c.Id == companyId);
        if (company == null)
        {
            throw new BusinessException(_localizationService.Get(CurrentMovementMessages.CompanyMustExist));
        }
    }

    public async Task DateMustBeWithinAccountingPeriod(DateTime date, int accountingPeriodId)
    {
        var period = await _accountingPeriodRepository.GetAsync(ap => ap.Id == accountingPeriodId);
        if (period != null && (date < period.StartDate || date > period.EndDate))
        {
            throw new BusinessException(_localizationService.Get(CurrentMovementMessages.DateMustBeWithinAccountingPeriod));
        }
    }
}

