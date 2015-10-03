using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMusicStore.DBContext
{
    public class MusicStoreDB : DbContext
    {
        public DbSet<AlbumInfo> AlbumInfos { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Artist> Artists { get; set; }
    }
}