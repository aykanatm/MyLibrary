using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Vision.v1.Data;
using MyLibrary.GoogleVision.Models;

namespace MyLibrary.GoogleVision.ExtensionMethods
{
    public static class SafeSearchAnnotationExtensionMethods
    {
        public static SafeSearchModel SafeSearchAnnotationsToModel(this SafeSearchAnnotation input)
        {
            return new SafeSearchModel
            {
                Adult = input.Adult,
                Medical = input.Medical,
                Spoof = input.Spoof,
                Violence = input.Violence
            };
        }
    }
}
