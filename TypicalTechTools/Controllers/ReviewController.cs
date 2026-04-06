using TypicalTechTools.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TypicalTechTools.Models.Repositories;
using NuGet.Protocol.Core.Types;

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

            if (reviews == null || !reviews.Any())
            {
                return RedirectToAction("AddReview", "Review", new { productCode = id });
            }

            ViewBag.ProductName = reviews.First().Product.ProductName;

            return View(reviews);
        }
        public ActionResult AddReview(int productCode)
        {
            var review = new Review { ProductCode = productCode };
            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview(Review review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _reviewRepo.AddReview(review);
                    return RedirectToAction("ReviewList", new { id = review.ProductCode });
                }
                return View(review);
            }
            catch
            {
                return View(review);
            }
        }

        public ActionResult EditReview(int reviewId)
        {
            var review = _reviewRepo.GetReviewById(reviewId);
            return View(review);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReview(Review review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _reviewRepo.EditReview(review);
                    return RedirectToAction("ReviewList", new { id = review.ProductCode });
                }
                return View(review);
            }
            catch
            {
                return View(review);
            }
        }

        public ActionResult RemoveReview(int reviewId)
        {
            var review = _reviewRepo.GetReviewById(reviewId);
            _reviewRepo.DeleteReview(review);
            return RedirectToAction("ReviewList", new { id = review.ProductCode });
        }
    }
}
