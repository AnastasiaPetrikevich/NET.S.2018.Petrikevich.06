using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinomial
{
    public class Polynomial
    {
        private readonly double[] coefficients;
        private int degree;

        public int Degree
        {
            get => degree;
            set => degree = coefficients.Length;
        }

        public Polynomial(params double[] array)
        {
            coefficients = new double[array.Length];
            Array.Copy(array, coefficients, array.Length);
        }


    }
}
