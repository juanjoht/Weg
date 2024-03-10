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
    public class ColorRepository : IColorRepository
    {
        private readonly DataContext _context;

        public ColorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ColorFenceModel>> Get()
        {

            List<ColorFenceModel> colors = await _context.ColorFence.ToListAsync();
            return colors;
        }
    }
}
