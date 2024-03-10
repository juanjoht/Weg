using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WegGridCore.Dto;
using WegGridCore.EF;

namespace WegGridCore.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            IEnumerable<OrderDto> orders = await (from c in _context.Order.Include("HeightFence").Include("ColorFence") 
                                           select new OrderDto 
                                           { 
                                             Id = c.Id,
                                             OrderDate = c.OrderDate,
                                             OrderDateFormat = c.OrderDate.ToString("dd/MM/yyyy HH:mm"),
                                             TotalLongFence = string.Format("{0} Mts",c.TotalLongFence),
                                             TotalLongGrid = string.Format("{0} Mts",c.TotalLongGrid),
                                             DifferenceFenceGrid = string.Format("{0} Mts",c.DifferenceFenceGrid),
                                             HeightFence = string.Format("{0} Mts",c.HeightFence.Name),
                                             ColorFence = c.ColorFence.Name
                                           }).OrderByDescending(x => x.OrderDate).ToListAsync();
            return orders;
        }

        public async Task<bool> Save<T>(T entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
