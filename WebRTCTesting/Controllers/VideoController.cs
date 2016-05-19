using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRTCTesting.Controllers
{
    public class VideoController : Controller
    {
        [Authorize]
        // GET: Video
        public ActionResult Index()
        {
            return View("Index2");
        }

        [Authorize]
        public ActionResult Index2()
        {
            return View("Index2");
        }

        public ActionResult Index3()
        {
            return View("Index3");
        }
    }
}