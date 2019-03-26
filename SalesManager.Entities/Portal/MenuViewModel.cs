using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Entities.Portal
{
    public class MenuViewModel
    {
        public int id { get; set; }
        public string url { get; set; }
        public string text { get; set; }
        public string icon_ad { get; set; }
        public int padreId { get; set; }
        public string onclick { get; set; }
        public bool openInNewWindow { get; set; }
    }
}
