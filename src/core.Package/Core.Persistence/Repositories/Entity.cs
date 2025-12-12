using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Persistence.Repositories;

public class Entity : IEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
