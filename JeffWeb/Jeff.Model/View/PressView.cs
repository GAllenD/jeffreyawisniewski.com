using System.Collections.Generic;

namespace Jeff.Model.View
{
    public class PressView
    {
        public List<PressShow> Shows { get; set; }

        public PressView()
        {
            Shows = new List<PressShow>();
        }
    }

    public class PressShow
    {
        public string Title { get; set; } 
        public List<ShowReview> Reviews { get; set; }

        public PressShow()
        {
            Reviews = new List<ShowReview>();
        }
    }

    public class ShowReview
    {
        public string Review { get; set; }    
        public string Credit { get; set; }    
    }
}
