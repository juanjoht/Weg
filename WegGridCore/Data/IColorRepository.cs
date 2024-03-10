using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WegGridCore.Models;

namespace WegGridCore.Data
{
    public interface IColorRepository
    {
        Task<IEnumerable<ColorFenceModel>> Get();

    }
}
