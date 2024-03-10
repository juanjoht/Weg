using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WegGridCore.Dto;

namespace WegGridApplication.Models
{
    public class OrderResultModel
    {
        public int Id { get; set; }
        public double TotalLongFence { get; set; }
        public int HeightFenceId { get; set; }
        [NotMapped]
        public double AmountGrid { get; set; }
        public int ColorFenceId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalLongGrid { get; set; }
        public double DifferenceFenceGrid { get; set; }
        [NotMapped]
        public List<OrderDto> OrderList { get; set; }
    }
}
