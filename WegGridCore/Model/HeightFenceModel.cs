using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WegGridCore.Models
{
    public class HeightFenceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HeightFenceId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrderModel> OrderModel { get; set; }
    }
}
