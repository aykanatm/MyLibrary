using System.Collections.Generic;
using MathUtils;

namespace CollectionUtils.ExtensionMethods
{
    public static class VectorExtensionMethods
    {
        public static Vector ToVector(this List<double> list)
        {
            return new Vector(list);
        }
    }
}
