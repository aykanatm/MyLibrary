using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.CustomMath;

namespace MyLibrary.CustomCollections.ExtensionMethods
{
    public static class VectorExtensionMethods
    {
        public static Vector ToVector(this List<double> list)
        {
            return new Vector(list);
        }
    }
}
