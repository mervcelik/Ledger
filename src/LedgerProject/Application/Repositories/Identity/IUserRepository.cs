using Core.Persistence.Repositories;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories.Identity;

public interface IUserRepository : IRepositoryAsync<User>
{
}
