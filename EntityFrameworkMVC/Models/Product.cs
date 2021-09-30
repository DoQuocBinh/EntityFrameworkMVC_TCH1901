using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkMVC.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public int? Category { get; set; }
        public byte[] Picture { get; set; }

        public virtual Category CategoryNavigation { get; set; }
    }
}


