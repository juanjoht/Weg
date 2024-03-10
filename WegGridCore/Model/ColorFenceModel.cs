using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WegGridCore.Models
{
    public class ColorFenceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColorFenceId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<OrderModel> OrderModel { get; set; }

    }
}
