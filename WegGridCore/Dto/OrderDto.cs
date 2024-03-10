using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WegGridCore.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string TotalLongFence { get; set; }
        public string HeightFence { get; set; }
        public string ColorFence { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderDateFormat { get; set; }
        public string TotalLongGrid { get; set; }
        public string DifferenceFenceGrid { get; set; }
    }
}
