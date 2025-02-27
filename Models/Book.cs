﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace stan_briana_labr2.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int? GenreID { get; set; }
        public Genre? Genre { get; set; }
        public int? AuthorID { get; set; }
        public Authors? Author { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
