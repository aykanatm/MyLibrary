using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.CustomMath.ExtensionMethods
{
    public static class VectorExtensionMethods
    {
        public static Matrix ToSingleColumnMatrix(this Vector vector)
        {
            return new Matrix(new List<Vector> { vector }, Matrix.VectorStyles.Column);
        }
        public static Matrix ToSingleRowMatrix(this Vector vector)
        {
            return new Matrix(new List<Vector> { vector }, Matrix.VectorStyles.Row);
        }
    }
}
