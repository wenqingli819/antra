using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Entity
{
    [Table("Cast")]
    public class FilmCast
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }
        public string ProfilePath { get; set; }
        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
