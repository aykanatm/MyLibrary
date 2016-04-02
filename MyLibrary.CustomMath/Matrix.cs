using System;
using System.Collections.Generic;
using System.Linq;
using MyLibrary.ClassOperations;

namespace MyLibrary.CustomMath
{
    [Serializable]
    public class Matrix
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public int Shape { get; private set; }

        public enum VectorStyles
        {
            Row,
            Column
        }

        private readonly double[][] _matrix;

        public Matrix(double[][] matrix)
        {
            _matrix = matrix;
            Columns = matrix.Length;
            Rows = matrix[0].Length;
            Shape = Rows * Columns;
        }

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Shape = Rows * Columns;

            _matrix = new double[rows][];
            for (var i = 0; i < rows; i++)
            {
                _matrix[i] = new double[columns];
            }

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    _matrix[i][j] = 0;
                }
            }
        }

        public Matrix(IList<Vector> vectors, VectorStyles vectorStyle)
        {
            if (vectors.Any())
            {
                if (vectorStyle == VectorStyles.Column)
                {
                    var rows = vectors[0].Dimensions;
                    var columns = vectors.Count;

                    Rows = rows;
                    Columns = columns;

                    _matrix = new double[rows][];
                    for (var i = 0; i < rows; i++)
                    {
                        _matrix[i] = new double[columns];
                    }

                    for (var i = 0; i < rows; i++)
                    {
                        for (var j = 0; j < columns; j++)
                        {
                            _matrix[i][j] = vectors[j].GetValueOfDimension(i);
                        }
                    }
                }
                else
                {
                    var rows = vectors.Count;
                    var columns = vectors[0].Dimensions;

                    Columns = columns;
                    Rows = rows;

                    _matrix = new double[rows][];
                    for (var i = 0; i < rows; i++)
                    {
                        _matrix[i] = new double[columns];
                    }

                    for (var i = 0; i < rows; i++)
                    {
                        for (var j = 0; j < columns; j++)
                        {
                            _matrix[i][j] = vectors[i].GetValueOfDimension(j);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("No vectors to make a matrix!");
            }
        }

        public double this[int i, int j]
        {
            get { return _matrix[i][j]; }
            set { _matrix[i][j] = value; }
        }

        public Vector GetColumn(int columnIndex)
        {
            var columnList = new List<double>();

            for (var i = 0; i < Rows; i++)
            {
                columnList.Add(_matrix[i][columnIndex]);
            }

            var result = new Vector(columnList);

            return result;
        }

        public Vector GetRow(int rowIndex)
        {
            var rowList = new List<double>();

            for (var i = 0; i < Columns; i++)
            {
                rowList.Add(_matrix[rowIndex][i]);
            }

            var result = new Vector(rowList);

            return result;
        }

        public Matrix Transpose()
        {
            var rowList = new List<Vector>();
            for (var i = 0; i < Rows; i++)
            {
                rowList.Add(GetRow(i));
            }

            var matrix = new Matrix(rowList, VectorStyles.Column);

            return matrix;
        }

        public static Matrix MatMul(Matrix a, Matrix b)
        {
            if (a.Shape != b.Shape)
            {
                throw new Exception("Matrices must be of equal shape");
            }

            var gc = new GenericCloner<Matrix>();
            var aClone = gc.Clone(a);
            var bClone = gc.Clone(b);

            var resultList = new List<Vector>();

            for (var i = 0; i < aClone.Rows; i++)
            {
                var resultRowList = new List<double>();

                for (var j = 0; j < bClone.Columns; j++)
                {
                    resultRowList.Add(Vector.DotProduct(aClone.GetRow(i), bClone.GetColumn(j)));
                }

                var resultRowVector = new Vector(resultRowList);

                resultList.Add(resultRowVector);
            }

            return new Matrix(resultList, VectorStyles.Row);
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Shape != b.Shape)
            {
                throw new Exception("Both matrices must be of same shape!");
            }

            var gc = new GenericCloner<Matrix>();
            var aClone = gc.Clone(a);
            var bClone = gc.Clone(b);

            var resultMatrix = new Matrix(a.Rows, a.Columns);
            for (var i = 0; i < resultMatrix.Rows; i++)
            {
                for (var j = 0; j < resultMatrix.Columns; j++)
                {
                    resultMatrix[i, j] = aClone[i, j] + bClone[i, j];
                }
            }

            return resultMatrix;
        }

        public static Matrix operator *(double a, Matrix b)
        {
            var gc = new GenericCloner<Matrix>();
            var bClone = gc.Clone(b);

            for (var i = 0; i < bClone.Rows; i++)
            {
                for (var j = 0; j < bClone.Columns; j++)
                {
                    bClone[i, j] *= a;
                }
            }

            return bClone;
        }

        public override string ToString()
        {
            string output = "[";

            for (var i = 0; i < Rows; i++)
            {
                if (i == 0)
                {
                    output += "(";
                }
                else
                {
                    output += " (";
                }

                for (var j = 0; j < Columns; j++)
                {
                    if (j != Columns - 1)
                    {
                        output += _matrix[i][j] + ",";
                    }
                    else
                    {
                        output += _matrix[i][j];
                    }
                }

                if (i != Rows - 1)
                {
                    output += ")\n";
                }
                else
                {
                    output += ")";
                }

            }

            output += "]";

            return output;
        }
    }
}
