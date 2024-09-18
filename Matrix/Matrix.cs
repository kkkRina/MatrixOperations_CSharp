using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Matrixx
{
    public class Matrix
    {
        private protected double[,] elems;
        public int Rows => elems.GetLength(0);
        public int Cols => elems.GetLength(1);
        public double? this[int row, int col]
        {
            
            get
            {
                
                if (row > this.Rows|| col > this.Cols)
                {
                    return null;
                }
                else
                {
                    return elems[row , col];
                }

            } 
            set => elems[row, col] = value ?? 0.0;
        }
        public Matrix Trmatrix
        {
            get
            {
                var trm = new Matrix(this.Cols, this.Rows);
                for (int i=0;i<this.Rows;i++)
                {
                    for(int j=0; j < this.Cols; j++)
                    {
                        trm[j,i] = this[i,j];
                    }
                }
                return trm;
            } 
        }
        public Matrix()
        {
            elems = new double[,] { { 0 } };
        }
        public Matrix(int rows, int cols)
        {
            elems = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    elems[i, j] = 0;
                }
            }
        }
        public Matrix(double[,] elements)
        {
            this.elems = new double[elements.GetLength(0),elements.GetLength(1)];
            Array.Copy(elements, this.elems, elements.Length);
        }
        public Matrix(Matrix existingMatrix)
        {
            elems = new double[existingMatrix.elems.GetLength(0), existingMatrix.elems.GetLength(1)];
            Array.Copy(existingMatrix.elems, elems, existingMatrix.elems.Length);
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows == b.Rows && a.Cols == b.Cols)
            {
                var result = new Matrix(a.Rows, a.Cols);
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Cols; j++)
                    {
                        result[i, j] = a[i, j] + b[i, j];
                    }
                }
                return result;
            }
            throw new InappropriateMatrixSizesException("Размеры матриц не позволяют выполнить операцию.");
        }
        public static Matrix operator *(Matrix a, double n)
        {
            var result = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    result[i, j] = a[i, j]*n;
                }
            }
            return result;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Rows==b.Cols && a.Cols == b.Rows)
            {
                var result = new Matrix(a.Rows, b.Cols);
                for (var i = 0; i < a.Rows; i++)
                {
                    for (var j = 0; j < b.Cols; j++)
                    {

                        for (var k = 0; k < a.Cols; k++)
                        {
                            result[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }

                return result;
            }
            throw new InappropriateMatrixSizesException("Размеры матриц не позволяют выполнить операцию.");
        }
        public static Matrix operator /(Matrix a, double n)
        {
            if (n == 0) { throw new DivisionByzeroException("Невозможно выполнить деление на 0"); }
            var result = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    result[i, j] = a[i, j] / n;
                }
            }
            return result;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows == b.Rows && a.Cols == b.Cols)
            {
                var result = new Matrix(a.Rows, a.Cols);
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Cols; j++)
                    {
                        result[i, j] = a[i, j] - b[i, j];
                    }
                }
                return result;
            }
            throw new InappropriateMatrixSizesException("Размеры матриц не позволяют выполнить операцию.");
        }
        public static bool operator ==(Matrix a, Matrix b)
        {
            bool ok = true;
            for (int i=0; i<a.Rows; i++)
            {
                for(int j=0; j < a.Cols; j++)
                {
                    if (a[i, j] != b[i, j])
                    {
                        ok = false;
                        return ok;
                    }
                }
            }
            return ok;
        }
        public static bool operator !=(Matrix a, Matrix b) => !(a == b);
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i=0; i < Rows; i++)
            {
                sb.Append('(');
                for(int j = 0; j < Cols; j++)
                {
                    if(j>0) sb.Append('\t');
                    sb.Append(elems[i, j]);
                }
                sb.Append(")\n"); 
            }   
            return sb.ToString();
        }
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }
        public override int GetHashCode()
        {
            var ehc = 0;
            foreach(var e in elems) {
                ehc = HashCode.Combine(ehc, e);
            }
            var hash = HashCode.Combine(ehc, Rows, Cols);
            return hash;
        }
        public class NotSquareMatrixException : Exception
        {
            public NotSquareMatrixException(string message) : base(message) { }
        }
        public class InappropriateMatrixSizesException : Exception
        {
            public InappropriateMatrixSizesException(string message) : base(message) { }
        }
        public class DivisionByzeroException : Exception
        {
            public DivisionByzeroException(string message) : base(message) { }
        }
    }
}
