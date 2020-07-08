﻿using C.R.E.A.M.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace C.R.E.A.M.Controllers
{
    public class StoreController : Controller
    {
        //private FakeDatabase _database = new FakeDatabase();
        StoreContext _storeContext = new StoreContext();

        // GET: Store
        public ActionResult Index()
        {
            var genres = _storeContext.Genres.Include("Albums");

           // var genres = _database.Genres;

            return View(genres);
        }

        public ActionResult Browse(string genre)
        {
            var genreModel = _storeContext.Genres.Include("Albums").Where(x => x.Name == genre).FirstOrDefault();


            return View(genreModel);
        }

        public ActionResult Detail(int id)
        {
            var album = _storeContext.Albums.Include("Artist").Include("Genre").Where(x => x.AlbumId == id).FirstOrDefault();

            return View(album);
        }
    }
}