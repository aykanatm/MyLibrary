using System.Collections.Generic;
using CustomMath;

namespace CustomCollections.ExtensionMethods
{
    public static class VectorExtensionMethods
    {
        public static Vector ToVector(this List<double> list)
        {
            return new Vector(list);
        }
    }
}
