using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.CustomMath
{
    public class GenericRescaler<T>
    {
        public static T Rescale(T value, T oldMin, T oldMax, T newMin, T newMax)
        {
            dynamic dynValue = value;

            dynamic dynOldMin = oldMin;
            dynamic dynOldMax = oldMax;

            dynamic dynNewMin = newMin;
            dynamic dynNewMax = newMax;

            return (dynValue - dynOldMin) / (dynOldMax - dynOldMin) * (dynNewMax - dynNewMin) + dynNewMin;
        }
    }
}
