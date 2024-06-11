using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurveyQuesion.DAL;
using SurveyQuesion.Models;


namespace SurveyQuesion.Controllers
{
    public class SurveyController : Controller
    {
        private SurveyContext db = new SurveyContext();
       
        public ActionResult Done()
        {
           
            return View();
        }

        // GET: Survey/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Survey/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FullNames,Email,DateOfBirth,Contact,Foods,Movies,Radio,EatOut,TV,Food1,Food2,Food3,Food4")] Survey survey)
        {
            int ratingMv = survey.Movies;// to make the checkbox an integer when insrted on a database
            int ratingRadio = survey.Radio;
            int ratingEO = survey.EatOut;
            int ratingTV = survey.TV;    

            if (ModelState.IsValid)
            {

                    db.survey.Add(survey);
                    db.SaveChanges();
                    return RedirectToAction("Done");
            }
            return View();
        }

        public ActionResult SurveyResponse()
        {
             
            var viewModel = db.survey.ToList();//rertun the database
            if (viewModel.Count == 0)//if the database is empty
            {
                ViewBag.error = "No survey Available";
            }
            else
            {
                int TotalAge = 0;
                int TruePizza = viewModel.Where(s => s.Food1).Count();//convert the boolean to int
                int TruePasta = viewModel.Where(s => s.Food2).Count();
                int TruePW = viewModel.Where(s => s.Food3).Count();
                var RateM = viewModel.Select(s => s.Movies).ToList();
                Decimal sumMovie = 0;
                Decimal sumRadio = 0;
                Decimal sumEatOut = 0;
                Decimal sumWtv = 0;
                int minAge = int.MaxValue; // is for a large value
                int maxAge = int.MinValue; // is for a small data          
                foreach (var item in viewModel)
                {
                    int age = DateTime.Today.Year - item.DateOfBirth.Year;
                    if (item.DateOfBirth.Date > DateTime.Today.AddYears(-age))
                    {
                        age--; // Adjust age if birthday hasn't occurred yet in a year
                    }
                    TotalAge += age;

                    if (age < minAge)
                    {
                        minAge = age;
                    }

                    if (age > maxAge)
                    {
                        maxAge = age;
                    }
                    sumMovie += item.Movies;//get the sum of each item 
                    sumRadio += item.Radio;
                    sumEatOut += item.EatOut;
                    sumWtv += item.TV;
                }
                Decimal avarageTv = (Decimal)sumWtv / viewModel.Count;
                Decimal avarageEO = (Decimal)sumEatOut / viewModel.Count;
                Decimal avarageR = (Decimal)sumRadio / viewModel.Count;
                Decimal avarageMv = (Decimal)sumMovie / viewModel.Count;
                Decimal avaragePW = (Decimal)TruePW / viewModel.Count * 100;
                Decimal avaragePasta = (Decimal)TruePasta / viewModel.Count * 100;
                Decimal avaragePizza = (Decimal)TruePizza / viewModel.Count * 100;
                Decimal averageAge = (Decimal)TotalAge / viewModel.Count;
                ViewBag.Total = viewModel.Count;
                ViewBag.AvgAge = averageAge;
                ViewBag.MinAge = minAge;
                ViewBag.MaxAge = maxAge;
                ViewBag.AvgPizza = avaragePizza;
                ViewBag.AvgPasta = avaragePasta;
                ViewBag.AvgPW = avaragePW;
                ViewBag.AvgMv = avarageMv;
                ViewBag.AvgRd = avarageR;
                ViewBag.AvgEO = avarageEO;
                ViewBag.AvgWtv = avarageTv;

            }
           
            return View();
        }
      

    }
}
