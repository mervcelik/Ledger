using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentAccounts.Constans;

public class CurrentAccountMessages
{
    public const string CANameCanNotBeDuplicated = "CA.NameCanNotBeDuplicated";
    public const string CANameNotNull = "CA.NameNotNull";
    public const string CATaxNumberNotNull = "CA.TaxNumberNotNull";
    public const string CACompanyIdNotNull = "CA.CompanyIdNotNull";
    public const string CACompanyMustExist = "CA.CompanyMustExist";
    public const string CATaxNumberMustBeUnique = "CA.TaxNumberMustBeUnique";
}
