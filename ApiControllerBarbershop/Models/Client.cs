﻿using System.ComponentModel.DataAnnotations;

namespace ApiControllerBarbershop.Models
{
    public partial class Client
    {
        [Key]
        public int IdClient { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronimyc { get; set; }
        public string NumberPhone { get; set; }
        public string Address { get; set; }
    }
}