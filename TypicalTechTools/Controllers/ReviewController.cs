using TypicalTechTools.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TypicalTechTools.Models.Repositories;

namespace TypicalTools.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IProductRepository _productRepo;

        public ReviewController(IReviewRepository reviewRepo, IProductRepository productRepo)
        {
            _reviewRepo = reviewRepo;
            _productRepo = productRepo;
        }

        [HttpGet]
        public ActionResult ReviewList(int id)
        {
            var reviews = _reviewRepo.GetReviews(id);

            ViewBag.ProductCode = id;


            if (reviews == null || !reviews.Any())
            {
                return RedirectToAction("AddReview", "Review", new { id = id });
            }

            ViewBag.ProductName = reviews.First().Product.ProductName;

            return View(reviews);
        }
    }
}
