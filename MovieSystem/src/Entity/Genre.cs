﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Entity
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
