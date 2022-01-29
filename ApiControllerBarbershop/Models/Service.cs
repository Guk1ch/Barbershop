using System;
using System.ComponentModel.DataAnnotations;

namespace ApiControllerBarbershop.Models
{
    public partial class Service
    {
        [Key]
        public int IdService { get; set; }
        public int IdTypeService { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] ImageInByte { get; set; }
        public string Description { get; set; }
    }
}