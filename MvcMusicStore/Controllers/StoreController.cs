using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/
        public string Index()
        {
            return "Hello from Store.Index";
        }

        public string Browse(string genre)
        {
            return "Hello from Store.Browse, Genre=" + genre;
        }

        public string Details()
        {
            return "Hello from Store.Details";
        }
	}
}