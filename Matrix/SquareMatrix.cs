using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Matrixx
{
    public class SquareMatrix : Matrix
    {
        public SquareMatrix() { }

        public SquareMatrix(int sz) : base(sz, sz) { }

        public SquareMatrix(double[,] elems) : base(elems)
        {
            if (Rows != Cols)
            {
                throw new NotSquareMatrixException("Матрица не квадратная.");
            }
        }
        public SquareMatrix(Matrix m) : base(m)
        {
            if (Cols != Rows)
            {
                 throw new NotSquareMatrixException("Матрица не квадратная."); 
            }
        }
        public SquareMatrix(SquareMatrix m) : base(m) { } 
        private SquareMatrix Minor(int row, int col)
        {
            double[,] me = new double[Rows - 1, Cols - 1];
            
            int mi = 0;
            for (int i = 0; i < Rows; i++)
            {
                int mj = 0;
                if (i == row) continue;
                for (int j = 0; j < Cols; j++)
                {
                    if (j == col) continue;
                    me[mi, mj] = this[i, j] ?? 0.0;
                    mj++;
                }
                mi++;
            }
            return new SquareMatrix(me);
        }
        private static SquareMatrix GaussMatrix(SquareMatrix m)
        {
            var res = new SquareMatrix(m);
            
            for (int i = 0; i < m.Rows - 1; i++)
            {
                var a = res[i, i];

                for (int j = i + 1; j < m.Cols; j++)
                {
                    int index = i;
                    var b = res[j, index];
                    var mn = (double)b / a;
                    while (index < m.Cols)
                    {
                        res[j, index] -= mn * res[i, index];
                        index++;
                    }
                }
            }
            return res;
        }
        private static double Det(SquareMatrix m)
        {
            var gMatrix = GaussMatrix(m);
            double d = 1;
            for (int i = 0; i < m.Rows; i++)
            {
                d *= gMatrix[i, i] ?? 0.0;
                
            }
            d = Math.Round(d, 5);
            if (Math.Abs(d) < 1e-20)
            {
                d = 0;
            }
            return d;
        }
        public SquareMatrix Inv(SquareMatrix m)
        {
            if (m.Determinant == 0)
            {
                throw new DivisionByzeroException("Обратная матрица не может быть вычислена. Невозможно выполнить деление на 0.");
            }
            double d = m.Determinant;
            SquareMatrix invm = new SquareMatrix(m.Rows);
            for (int i = 0; i < m.Rows; i++)
            {
                for(int j = 0; j < m.Cols; j++)
                {
                    invm[i, j] = ((i+j) % 2 == 0 ? 1 : -1) * this.Minor(j, i).Determinant / d;
                }
            }
            return invm;
        }
        public double Determinant
        {
            get => Det(this);
        }
        public SquareMatrix InvMatrix
        {
            get => Inv(this);
        }
    }
}
