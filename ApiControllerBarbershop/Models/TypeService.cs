using System.ComponentModel.DataAnnotations;

namespace ApiControllerBarbershop.Models
{
    public partial class TypeService
    {
        [Key]
        public int IdTypeService { get; set; }
        public string Name { get; set; }
    }
}