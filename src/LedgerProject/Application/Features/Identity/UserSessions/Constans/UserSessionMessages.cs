using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Identity.UserSessions.Constans;

public class UserSessionMessages
{
    public const string UserSessionIdGreaterThanZero = "UserSession.IdGreaterThanZero";
    public const string UserSessionUserIdNotEmpty = "UserSession.UserIdNotEmpty";
    public const string UserSessionUserMustExist = "UserSession.UserMustExist";
    public const string UserSessionAccessTokenCannotBeEmpty = "UserSession.AccessTokenCannotBeEmpty";
    public const string UserSessionRefreshTokenCannotBeEmpty = "UserSession.RefreshTokenCannotBeEmpty";
    public const string UserSessionExpirationDateCannotBeEmpty = "UserSession.ExpirationDateCannotBeEmpty";
}
