using MvcMusicStore.Models;
using System.Data.Entity;

namespace MvcMusicStore.DBContext
{
    public class MusicStoreDb : DbContext
    {
        public DbSet<AlbumInfo> AlbumInfos { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Artist> Artists { get; set; }
    }
}