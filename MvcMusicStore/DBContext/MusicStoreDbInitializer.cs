using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcMusicStore.Models;

namespace MvcMusicStore.DBContext
{
    public class MusicStoreDbInitializer : DropCreateDatabaseAlways<MusicStoreDb>
    {
        protected override void Seed(MusicStoreDb context)
        {
            context.Artists.Add(new Artist {Name = "Al Di Meola"});
            context.Genres.Add(new Genre {Name = "Jazz"});
            context.AlbumInfos.Add(new AlbumInfo
            {
                Artist = new Artist { Name = "Rush"},
                Genre = new Genre { Name = "Rock"},
                Price = 9.99m,
                Title = "Caravan"
            });

            base.Seed(context);
        }
    }
}