using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WegGridCore.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public double TotalLongFence { get; set; }
        public int HeightFenceId { get; set; }
        public int ColorFenceId { get; set;}
        public DateTime OrderDate { get; set;}
        public double TotalLongGrid { get; set; }
        public double DifferenceFenceGrid { get; set; }

        [ForeignKey("HeightFenceId")]
        public virtual HeightFenceModel HeightFence { get; set; }
        [ForeignKey("ColorFenceId")]
        public virtual ColorFenceModel ColorFence { get; set; }
    }
}
