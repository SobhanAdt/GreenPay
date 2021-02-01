using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenPay.Controllers
{
    public class NewsController : Controller
    {
        GreenPayContext db = new GreenPayContext();
        private IPageRepository pageRepository;

        private IPageGroupRepository pageGroupRepository;

        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
        }
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PagePost()
        {
            return PartialView(pageGroupRepository.GetGroupForview());
        }

        public ActionResult PostFarvrit()
        {
            return PartialView(pageRepository.TopNews());
        }


        public ActionResult LastNews()
        {
            return PartialView(pageRepository.LastNews());
        }

        public ActionResult PostFarvritInFooter()
        {
            return PartialView(pageRepository.TopNews());
        }

        [Route("Group/{id}/{title}")]
        public ActionResult ShowNewsByGroupId(int id, string title)
        {
            ViewBag.name = title;
            return View(pageRepository.ShowPageByGroup(id));
        }

        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var news = pageRepository.GetPageById(id);
            if (news == null)
            {
                return HttpNotFound();
            }

            news.Visit += 1;
            pageRepository.UpdatePage(news);
            pageRepository.Save();
            return View(news);

        }

        public ActionResult NewsCommnet()
        {
            return PartialView();
        }
    }
}