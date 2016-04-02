using System;
using System.Collections;
using System.Collections.Generic;
using MyLibrary.ClassOperations;

namespace MyLibrary.CustomMath
{
    [Serializable]
    public class Vector : IEnumerable
    {
        private readonly List<double> _elements;
        public int Dimensions;

        public Vector()
        {
            _elements = new List<double>();
        }

        public Vector(int dimensions)
        {
            Dimensions = dimensions;
            _elements = new List<double>(dimensions);
            dynamic placeholder = 0;

            for (var i = 0; i < dimensions; i++)
            {
                _elements.Add(placeholder);
            }
        }

        public Vector(List<double> elements)
        {
            Dimensions = elements.Count;
            _elements = elements;
        }

        public void Add(double value)
        {
            _elements.Add(value);
            Dimensions += 1;
        }

        public void Clear()
        {
            _elements.Clear();
            Dimensions = 0;
        }

        public void SetDimensionValue(int index, double value)
        {
            _elements[index] = value;
        }

        public double GetValueOfDimension(object sender, int index)
        {
            return _elements[index];
        }

        public double GetValueOfDimension(int index)
        {
            return _elements[index];
        }

        public static Vector operator -(Vector left, Vector right)
        {
            if (left.Dimensions != right.Dimensions)
            {
                throw new Exception("Both vectors must be of same size!");
            }
            var leftCopy = DeepCopy(left);
            var rightCopy = DeepCopy(right);

            var output = new Vector(leftCopy.Dimensions);

            for (int i = 0; i < left.Dimensions; i++)
            {
                output._elements[i] = leftCopy._elements[i] - rightCopy._elements[i];
            }

            return output;
        }
        public static Vector operator +(Vector left, Vector right)
        {
            if (left.Dimensions != right.Dimensions)
            {
                throw new Exception("Both vectors must be of same size!");
            }
            var leftCopy = DeepCopy(left);
            var rightCopy = DeepCopy(right);

            var output = new Vector(leftCopy.Dimensions);

            for (int i = 0; i < left.Dimensions; i++)
            {
                output._elements[i] = leftCopy._elements[i] + rightCopy._elements[i];
            }

            return output;
        }
        public static Vector operator *(double value, Vector vector)
        {
            dynamic dynValue = value;

            var output = DeepCopy(vector);

            for (int i = 0; i < vector.Dimensions; i++)
            {
                output._elements[i] = dynValue * output._elements[i];
            }
            return output;
        }

        public static double AvgError(Vector expected, Vector output)
        {
            if (expected.Dimensions != output.Dimensions)
            {
                throw new Exception("Both vectors must be of same size!");
            }

            var errorPercentageVector = new Vector();

            for (var i = 0; i < expected.Dimensions; i++)
            {

                errorPercentageVector.Add(Math.Abs(expected.GetValueOfDimension(i) - output.GetValueOfDimension(i)));
            }

            double sum = 0;
            for (var i = 0; i < errorPercentageVector.Dimensions; i++)
            {
                sum += errorPercentageVector.GetValueOfDimension(i);
            }

            return sum / errorPercentageVector.Dimensions;
        }

        public static Vector ElementProduct(Vector a, Vector b)
        {
            if (a.Dimensions != b.Dimensions)
            {
                throw new Exception("Both vectors must be of same size!");
            }

            var aClone = DeepCopy(a);
            var bClone = DeepCopy(b);

            var outputList = new List<double>();

            for (var i = 0; i < a.Dimensions; i++)
            {
                outputList.Add(aClone.GetValueOfDimension(i) * bClone.GetValueOfDimension(i));
            }

            var output = new Vector(outputList);

            return output;
        }

        public override string ToString()
        {
            var output = "Vector" + Dimensions + "(";

            for (var i = 0; i < _elements.Count; i++)
            {
                if (i != _elements.Count - 1)
                {
                    output += _elements[i] + ", ";
                }
                else
                {
                    output += _elements[i];
                }
            }

            output += ")";

            return output;
        }

        private static Vector DeepCopy(Vector other)
        {
            var gc = new GenericCloner<Vector>();
            return gc.Clone(other);
        }

        public static double DotProduct(Vector a, Vector b)
        {
            if (a.Dimensions != b.Dimensions)
            {
                throw new Exception("Both vectors must be of same size!\n" + a + "\n" + b);
            }

            dynamic output = 0;

            for (var i = 0; i < a.Dimensions; i++)
            {
                output = output + a._elements[i] * b._elements[i];
            }

            return output;
        }

        public static double Magnitude(Vector vector)
        {
            dynamic dimensionPow = 0;

            for (var i = 0; i < vector.Dimensions; i++)
            {
                dimensionPow += Math.Pow(vector.GetValueOfDimension(i), 2);
            }

            return Math.Sqrt(Math.Sqrt(dimensionPow));
        }

        public static Vector Normalize(Vector vector)
        {
            var v = DeepCopy(vector);
            for (var i = 0; i < vector.Dimensions; i++)
            {
                var upperValue = v.GetValueOfDimension(i);
                var lowerValue = Magnitude(v);
                if (lowerValue != 0)
                {
                    v.SetDimensionValue(i, upperValue / lowerValue);
                }
                else
                {
                    v.SetDimensionValue(i, 0);
                }
            }
            return v;
        }

        public static Vector Abs(Vector vector)
        {
            var v = DeepCopy(vector);

            for (var i = 0; i < v.Dimensions; i++)
            {
                v.SetDimensionValue(i, Math.Abs(v.GetValueOfDimension(i)));
            }

            return v;
        }

        public IEnumerator GetEnumerator()
        {
            return _elements.GetEnumerator();
        }
    }
}
