using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentMovements.Constans;

public class CurrentMovementMessages
{
    public const string CurrentAccountMustExist = "CurrentMovement.CurrentAccountMustExist";
    public const string AccountingPeriodMustExist = "CurrentMovement.AccountingPeriodMustExist";
    public const string AccountingPeriodMustNotBeClosed = "CurrentMovement.AccountingPeriodMustNotBeClosed";
    public const string MovementTypeMustExist = "CurrentMovement.MovementTypeMustExist";
    public const string CompanyMustExist = "CurrentMovement.CompanyMustExist";
    public const string DateMustBeWithinAccountingPeriod = "CurrentMovement.DateMustBeWithinAccountingPeriod";
    public const string AmountMustBeGreaterThanZero = "CurrentMovement.AmountMustBeGreaterThanZero";
    public const string DescriptionCannotBeEmpty = "CurrentMovement.DescriptionCannotBeEmpty";
}

