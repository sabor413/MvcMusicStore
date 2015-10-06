using System.Collections.Generic;

namespace MvcMusicStore.Models
{
    public class AlbumInfo
    {
        public virtual int      AlbumInfoId { get; set; }
        public virtual int      GenreId     { get; set; }
        public virtual int      ArtistId    { get; set; }
        public virtual string   Title       { get; set; }
        public virtual decimal  Price       { get; set; }
        public virtual string   AlbumArtUrl { get; set; }
        public virtual Artist   Artist      { get; set; }
        public virtual Genre    Genre       { get; set; }
    }

    public class Artist
    {
        public virtual int ArtistId { get; set; }
        public virtual string Name { get; set; }
    }

    public class Genre
    {
        public virtual int GenreId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual List<AlbumInfo> Albums { get; set; }
    }
}