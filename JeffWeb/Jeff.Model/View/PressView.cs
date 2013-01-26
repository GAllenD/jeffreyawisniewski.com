using System.Collections.Generic;

namespace Jeff.Model.View
{
    public class PressView
    {
        public List<PressShow> Shows { get; set; }
    }

    public class PressShow
    {
        public string Title { get; set; } 
        public List<ShowReview> Reviews { get; set; }
    }

    public class ShowReview
    {
        public string Review { get; set; }    
        public string Credit { get; set; }    
    }
}
