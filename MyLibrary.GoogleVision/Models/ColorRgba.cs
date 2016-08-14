using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Vision.v1.Data;

namespace MyLibrary.GoogleVision.Models
{
    public class ColorRgba
    {
        public float R { get;}
        public float G { get;}
        public float B { get;}
        public float A { get;}

        public ColorRgba(ColorInfo colorInfo)
        {
            R = colorInfo.Color.Red != null ? colorInfo.Color.Red.Value : 0;
            G = colorInfo.Color.Green != null ? colorInfo.Color.Green.Value : 0;
            B = colorInfo.Color.Blue != null ? colorInfo.Color.Blue.Value : 0;
            A = colorInfo.Color.Alpha != null ? colorInfo.Color.Alpha.Value : 0;
        }
    }
}
