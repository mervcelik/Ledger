using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Identity.UserOperationClaims.Constans;

public class UserOperationClaimMessages
{
    public const string UserOperationClaimNotUnique = "UserOperationClaim.NotUnique";
    public const string UserOperationClaimIdGreaterThanZero = "UserOperationClaim.IdGreaterThanZero";
    public const string UserOperationClaimUserIdNotEmpty = "UserOperationClaim.UserIdNotEmpty";
    public const string UserOperationClaimOperationClaimIdNotEmpty = "UserOperationClaim.OperationClaimIdNotEmpty";
    public const string UserOperationClaimUserMustExist = "UserOperationClaim.UserMustExist";
    public const string UserOperationClaimOperationClaimMustExist = "UserOperationClaim.OperationClaimMustExist";
}
