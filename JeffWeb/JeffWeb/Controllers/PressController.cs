using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jeff.Model.Domain;
using Jeff.Model.View;

namespace JeffWeb.Controllers
{
    public class PressController : ConfigurableController
    {
        public ActionResult Index()
        {
            return View(CreateView());
        }

        public override PageType Page()
        {
            return PageType.Press;
        }

        public PressView CreateView()
        {
            var pressView = new PressView();

            var uniqueShows = _pageConfigurations.Select(p => p.Title).Distinct();

            foreach (var show in uniqueShows)
            {
                var s = show;
                var showReviews = _pageConfigurations.Where(p => p.Title == s);

                var view = new PressShow()
                {
                    Title = show,
                };

                foreach (var review in showReviews)
                {
                    view.Reviews.Add(new ShowReview{ Credit =  review.Credit, Review = review.Text});
                }

                pressView.Shows.Add(view);

            }

            return pressView;
        }
    }
}
