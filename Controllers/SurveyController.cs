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
            // to make the checkbox an integer when insrted on a database
            int ratingMv = survey.Movies;
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
                double TotalAge = 0;
                double TruePizza = viewModel.Where(s => s.Food1).Count();//convert the boolean to int
                double TruePasta = viewModel.Where(s => s.Food2).Count();
                double TruePW = viewModel.Where(s => s.Food3).Count();
              
                double sumMovie = 0;
                double sumRadio = 0;
                double sumEatOut = 0;
                double sumWtv = 0;
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
                    sumMovie += item.Movies;
                    sumRadio += item.Radio;
                    sumEatOut += item.EatOut;
                    sumWtv += item.TV;
                }
                double avarageTv = Math.Round(sumWtv / viewModel.Count,2);
                double avarageEO = Math.Round(sumEatOut / viewModel.Count,2);
                double avarageR = Math.Round(sumRadio / viewModel.Count,2);
                double avarageMv = Math.Round(sumMovie / viewModel.Count,2);
                double avaragePW = Math.Round(TruePW / viewModel.Count * 100,2);
                double avaragePasta = Math.Round(TruePasta / viewModel.Count * 100,2);
                double avaragePizza = Math.Round(TruePizza / viewModel.Count * 100,2);
                double averageAge = Math.Round(TotalAge / viewModel.Count,2);
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
