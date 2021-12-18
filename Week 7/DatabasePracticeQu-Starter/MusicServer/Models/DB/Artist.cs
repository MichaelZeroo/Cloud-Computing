using System;
using System.Collections.Generic;

namespace MusicServer.Models.DB
{
    public partial class Artist
    {
        public Artist()
        {
            Album = new HashSet<Album>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }

        public ICollection<Album> Album { get; set; }
    }
}
