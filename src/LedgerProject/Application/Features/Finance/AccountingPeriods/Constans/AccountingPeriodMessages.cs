using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.AccountingPeriods.Constans;

public static class AccountingPeriodMessages
{
    public const string APNameNotNull = "AP.NameNotNull";
    public const string APNameNotUniqie = "AP.NameNotUniqie";
    public const string APEndDateLessThanStartDate = "AP.EndDateLessThanStartDate";
    public const string APStartDateGraterThanEndDate = "AP.StartDateGraterThanEndDate";
    public const string APCompanyIdGreaterThanZero = "AP.CompanyIdGreaterThanZero";
    public const string APDateRangeMustNotOverlap = "AP.DateRangeMustNotOverlap";
}
