using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltudoBtc1.Feature.DetailPage.Models
{
    public class ReviewComment
    {
        public string Name { get; set; }

        public string EmailId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime PostedDate { get; set; }
    }
}