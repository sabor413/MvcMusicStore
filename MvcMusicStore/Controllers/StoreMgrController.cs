namespace MvcMusicStore.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using MvcMusicStore.Models;
    using MvcMusicStore.DBContext;

    public class StoreMgrController : Controller
    {
        private readonly MusicStoreDb _db = new MusicStoreDb();

        // GET: /StoreMgr/
        public ActionResult Index()
        {
            var albuminfos = _db.AlbumInfos.Include(a => a.Artist).Include(a => a.Genre);
            return View(albuminfos.ToList());
        }

        // GET: /StoreMgr/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumInfo albuminfo = _db.AlbumInfos.Find(id);
            if (albuminfo == null)
            {
                return HttpNotFound();
            }
            return View(albuminfo);
        }

        // GET: /StoreMgr/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Name");
            ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
            return View();
        }

        // POST: /StoreMgr/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AlbumInfoId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] AlbumInfo albuminfo)
        {
            if (ModelState.IsValid)
            {
                _db.AlbumInfos.Add(albuminfo);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Name", albuminfo.ArtistId);
            ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name", albuminfo.GenreId);
            return View(albuminfo);
        }

        // GET: /StoreMgr/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumInfo albuminfo = _db.AlbumInfos.Find(id);
            if (albuminfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Name", albuminfo.ArtistId);
            ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name", albuminfo.GenreId);
            return View(albuminfo);
        }

        // POST: /StoreMgr/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AlbumInfoId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] AlbumInfo albuminfo)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(albuminfo).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Name", albuminfo.ArtistId);
            ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name", albuminfo.GenreId);
            return View(albuminfo);
        }

        // GET: /StoreMgr/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumInfo albuminfo = _db.AlbumInfos.Find(id);
            if (albuminfo == null)
            {
                return HttpNotFound();
            }
            return View(albuminfo);
        }

        // POST: /StoreMgr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlbumInfo albuminfo = _db.AlbumInfos.Find(id);
            _db.AlbumInfos.Remove(albuminfo);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
