using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    /// <summary>
    /// Contains methods for work with polynomials.
    /// </summary>
    public class Polynomial
    {
        /// <summary>
        /// Contains polynomials coefficients.
        /// </summary>
        private readonly double[] coefficients;

        /// <summary>
        /// Create polinomial.
        /// </summary>
        /// <param name="array">List of coefficients.</param>
        public Polynomial(params double[] array)
        {
            coefficients = new double[array.Length];
            Array.Copy(array, coefficients, array.Length);
        }

        /// <summary>
        /// Sum of two polynomials.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="rhs">Second polynomial.</param>
        /// <returns>Sum of two polynomial in new polinomial.</returns>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs) => Add(lhs, rhs);

        /// <summary>
        /// Sum of polynomial and number.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="number">Number.</param>
        /// <returns>Sum in new polinomial.</returns>
        public static Polynomial operator +(Polynomial lhs, double number) => Add(lhs, number);

        /// <summary>
        /// Sum of two polynomials.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="rhs">Second polynomial.</param>
        /// <returns>Sum of two polynomial.</returns>
        public static Polynomial Add(Polynomial lhs, Polynomial rhs)
        {
            if (lhs.coefficients == null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            if (rhs.coefficients == null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            double[] array;

            if (lhs.coefficients.Length <= rhs.coefficients.Length)
            {
                array = new double[rhs.coefficients.Length];
                for (int i = 0; i < rhs.coefficients.Length; i++)
                {
                    array[i] = rhs.coefficients[i];
                }
                for (int i = 0; i < lhs.coefficients.Length; i++)
                {
                    array[i] += lhs.coefficients[i];
                }
            }

            else
            {
                array = new double[lhs.coefficients.Length];
                for (int i = 0; i < lhs.coefficients.Length; i++)
                {
                    array[i] = lhs.coefficients[i];
                }
                for (int i = 0; i < rhs.coefficients.Length; i++)
                {
                    array[i] += rhs.coefficients[i];
                }
            }

            return new Polynomial(array);
        }

        /// <summary>
        /// Sum of polynomial and number.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="number">Number.</param>
        /// <returns>Sum in new polinomial.</returns>
        public static Polynomial Add(Polynomial lhs, double number)
        {
            if (lhs.coefficients == null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            double[] array = new double[lhs.coefficients.Length];
            array[0] = lhs.coefficients[0] + number;

            for (int i = 1; i < lhs.coefficients.Length; i++)
            {
                array[i] = lhs.coefficients[i];
            }

            return new Polynomial(array);
        }

        /// <summary>
        /// Difference of two polynomials.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="rhs">Second polynomial.</param>
        /// <returns> Difference of two polynomial in new polinomial.</returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs) => Substract(lhs, rhs);

        /// <summary>
        /// Difference of polynomial and number.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="number">Number.</param>
        /// <returns>Difference in new polinomial.</returns>
        public static Polynomial operator -(Polynomial lhs, double number) => Substract(lhs, number);

        /// <summary>
        /// Difference of two polynomials.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="rhs">Second polynomial.</param>
        /// <returns> Difference of two polynomial in new polinomial.</returns>
        public static Polynomial Substract(Polynomial lhs, Polynomial rhs)
        {
            if (lhs.coefficients == null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            if (rhs.coefficients == null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            double[] array;

            if (lhs.coefficients.Length <= rhs.coefficients.Length)
            {
                array = new double[rhs.coefficients.Length];
                for (int i = 0; i < rhs.coefficients.Length; i++)
                {
                    array[i] = rhs.coefficients[i];
                }
                for (int i = 0; i < lhs.coefficients.Length; i++)
                {
                    array[i] -= lhs.coefficients[i];
                }
            }

            else
            {
                array = new double[rhs.coefficients.Length];
                for (int i = 0; i < lhs.coefficients.Length; i++)
                {
                    array[i] = lhs.coefficients[i];
                }
                for (int i = 0; i < rhs.coefficients.Length; i++)
                {
                    array[i] -= rhs.coefficients[i];
                }
            }

            return new Polynomial(array);
        }

        /// <summary>
        /// Difference of polynomial and number.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="number">Number.</param>
        /// <returns>Difference in new polinomial.</returns>
        public static Polynomial Substract(Polynomial lhs, double number)
        {
            if (lhs.coefficients == null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            double[] array = new double[lhs.coefficients.Length];
            array[0] = lhs.coefficients[0] - number;

            for (int i = 1; i < lhs.coefficients.Length; i++)
            {
                array[i] = lhs.coefficients[i];
            }

            return new Polynomial(array);
        }

        /// <summary>
        /// Composition of two polynomials.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="rhs">Second polynomial.</param>
        /// <returns> Composition of two polynomial in new polinomial.</returns>
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs) => Multiply(lhs, rhs);

        /// <summary>
        /// Composition of polynomial and number.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="number">Number.</param>
        /// <returns>Composition in new polinomial.</returns>
        public static Polynomial operator *(Polynomial lhs, double number) => Multiply(lhs, number);

        /// <summary>
        /// Composition of two polynomials.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="rhs">Second polynomial.</param>
        /// <returns> Composition of two polynomial in new polinomial.</returns>   
        public static Polynomial Multiply(Polynomial lhs, Polynomial rhs)
        {
            if (lhs.coefficients == null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            if (rhs.coefficients == null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            double[] array = new double[lhs.coefficients.Length + rhs.coefficients.Length];
            for (int i = 0; i < lhs.coefficients.Length; i++)
            {
                for (int j = 0; j < rhs.coefficients.Length; j++)
                {
                    array[i + j] += rhs.coefficients[i] * lhs.coefficients[j];
                }
            }
            return new Polynomial(array);
        }

        /// <summary>
        /// Composition of polynomial and number.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="number">Number.</param>
        /// <returns>Composition in new polinomial.</returns>
        public static Polynomial Multiply(Polynomial lhs, double number)
        {
            if (lhs.coefficients == null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            double[] array = new double[lhs.coefficients.Length];
            for (int i = 0; i < lhs.coefficients.Length; i++)
            {
                array[i] = lhs.coefficients[i] * number;
            }

            return new Polynomial(array);
        }

        /// <summary>
        /// Cheks the equality of two polynomials.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="rhs">Second polynomial.</param>
        /// <returns>True if polynomials equal.</returns>
        public static bool operator ==(Polynomial lhs, Polynomial rhs) => IsEquals(lhs, rhs);

        /// <summary>
        /// Cheks the inequality of two polynomials.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="rhs">Second polynomial.</param>
        /// <returns>True if polynomials not equal.</returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs) => !IsEquals(lhs, rhs);

        /// <summary>
        /// Cheks the equality of two polynomials.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="rhs">Second polynomial.</param>
        /// <returns>True if polynomials equal.</returns>
        public static bool IsEquals(Polynomial lhs, Polynomial rhs)
        {
            if (lhs.coefficients.Length != rhs.coefficients.Length)
            {
                return false;
            }
            for (int i = 0; i < lhs.coefficients.Length; i++)
            {
                if (lhs.coefficients[i] != rhs.coefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Override method of System.Object. Cheks the equality of two polynomials.
        /// </summary>
        /// <param name="rhs">Polynomial.</param>
        /// <returns>True if polynomials equal.</returns>
        public override bool Equals(object rhs)
        {
            Polynomial polinomial = rhs as Polynomial;

            if (polinomial.coefficients.Length != this.coefficients.Length)
            {
                return false;
            }

            for (int i = 0; i < polinomial.coefficients.Length; i++)
            {
                if (polinomial.coefficients[i] != this.coefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// /// Override method of System.Object.
        /// </summary>
        /// <returns>String representation of the polynomial.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = coefficients.Length - 1; i >= 0; i--)
            {
                result.AppendFormat("{0}{1}{2}", coefficients[i] > 0 ? "+" : "", coefficients[i] != 0 && i != 0 ? (coefficients[i]) + "x^" + i : "", i == 0 ? coefficients[i] + "=0" : "");
            }
            return result.ToString();
        }

        /// <summary>
        /// /// Override method of System.Object.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
