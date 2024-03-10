using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WegGridCore.EF;
using WegGridCore.Models;

namespace WegGridCore.Data
{
    public class HeightRepository : IHeightRepository
    {
        private readonly DataContext _context;

        public HeightRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HeightFenceModel>> Get()
        {
            List<HeightFenceModel> heights = await _context.HeightFence.ToListAsync();
            return heights;
        }
    }
}
