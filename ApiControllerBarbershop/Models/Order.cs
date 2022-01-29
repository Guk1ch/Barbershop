using System.ComponentModel.DataAnnotations;

namespace ApiControllerBarbershop.Models
{
    public partial class Order
    {
        [Key]
        public int IdOrder { get; set; }
        public int IdClient { get; set; }
        public int IdService { get; set; }
        public System.DateTime DateOfCompletion { get; set; }
        public bool Done { get; set; }
    }
}