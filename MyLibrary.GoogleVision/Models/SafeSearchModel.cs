using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.GoogleVision.Models
{
    public class SafeSearchModel
    {
        public string Adult { get; set; }
        public string Violence { get; set; }
        public string Spoof { get; set; }
        public string Medical { get; set; }
    }
}
