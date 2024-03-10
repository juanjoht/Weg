using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WegGridCore.Dto;

namespace WegGridCore.Data
{
    public interface IOrderRepository
    {
       Task<bool> Save<T>(T entity);

       Task<IEnumerable<OrderDto>> GetOrders();
    }
}
