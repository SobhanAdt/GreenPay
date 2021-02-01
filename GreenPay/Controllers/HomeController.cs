using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace GreenPay.Controllers
{
    public class HomeController : Controller
    {
        GreenPayContext db = new GreenPayContext();
        private ITeamRepositoru TeamRepository;
        private ITeamAboutRepository teamAboutRepository;
        private IHamkaranRepository _hamkaranRepository;
        private ISliderRepository _sliderRepository;

        public HomeController()
        {
            TeamRepository = new TeamMemberRepository(db);
            teamAboutRepository = new TeamAboutRepository(db);
            _hamkaranRepository = new HamkaranRepository(db);
            _sliderRepository = new SliderRepository(db);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(TeamRepository.GetAllTeamMembers());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Services()
        {
            return View(db.Services);
        }

        public ActionResult SliderAtHome()
        {
            return PartialView(_sliderRepository.GetAllSlider());
        }

        public ActionResult MenuBar()
        {
            return PartialView();
        }

        public ActionResult HamKaranMa()
        {
            return PartialView(_hamkaranRepository.GetAllHamkarans());
        }

        public ActionResult WhatWork()
        {
            return PartialView();
        }

        public ActionResult ActiveWork()
        {
            return PartialView(db.Activities);
        }

        public ActionResult AboutDescription()
        {
            return PartialView(teamAboutRepository.GetAllAboutDescriptions());
        }

        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}