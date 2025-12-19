using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Dtos;

public class GetListResponse<T> : BasePageableModel
{
    private List<T> _items;

    public List<T> Items
    {
        get => _items ??= new List<T>();
        set => _items = value;
    }
}
