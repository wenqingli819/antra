﻿using System.Collections.Generic;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public class CastResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }
        public string ProfilePath { get; set; }

        public string Character { get; set; }

    }
}