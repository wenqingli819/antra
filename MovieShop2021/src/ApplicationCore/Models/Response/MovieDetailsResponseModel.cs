﻿using System;
using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.ServiceInterfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApplicationCore.Models.Response
{
    public class MovieDetailsResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
        public string Overview { get; set; }
        public string Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string ImdbUrl { get; set; }
        public string TmdbUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }

        public decimal? Rating { get; set; }
        public int FavoritesCount { get; set; }

        public List<CastResponseModel> Casts { get; set; }
        public List<GenreModel> Genres { get; set; }

    }
}
