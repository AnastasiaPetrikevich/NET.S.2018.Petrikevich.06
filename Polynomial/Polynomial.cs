using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Polynomial
{
    /// <summary>
    /// Contains methods for work with polynomials.
    /// </summary>
    public sealed class Polynomial
    {
        /// <summary>
        /// Contains polynomials coefficients.
        /// </summary>
        private readonly double[] coefficients = { };

        /// <summary>
        /// Accuracy.
        /// </summary>
        public static double epsilon ;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Polynomial()
        {
            epsilon = double.Parse(System.Configuration.ConfigurationManager.AppSettings["epsilon"]);
        }

        /// <summary>
        /// Get a polynomial degree.
        /// </summary>
        public int Degree
        {
            get
            {
                for (int i = this.coefficients.Length - 1; i >= 0; i--)
                {
                    if (Math.Abs(this.coefficients[i]) > epsilon)
                    {
                        return i;
                    }
                }

                return -1;
            }
        }

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
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            if (ReferenceEquals(rhs, null))
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            double[] array;

            if (lhs.Degree > rhs.Degree)
            {
                array = new double[lhs.Degree + 1];
                for (int i = 0; i < lhs.Degree + 1; i++)
                {
                    array[i] = lhs.coefficients[i];
                }

                for (int i = 0; i <= rhs.Degree + 1; i++)
                {
                    array[i] += rhs.coefficients[i];
                }
            }

            else
            {
                array = new double[rhs.Degree + 1];
                for (int i = 0; i < rhs.Degree + 1; i++)
                {
                    array[i] = rhs.coefficients[i];
                }

                for (int i = 0; i < lhs.Degree + 1; i++)
                {
                    array[i] += lhs.coefficients[i];
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
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            double[] array = new double[lhs.Degree + 1];
            array[0] = lhs.coefficients[0] + number;

            for (int i = 1; i < lhs.Degree + 1; i++)
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
            return Add(lhs, Multiply(rhs, -1));
        }

        /// <summary>
        /// Difference of polynomial and number.
        /// </summary>
        /// <param name="lhs">First polynomial.</param>
        /// <param name="number">Number.</param>
        /// <returns>Difference in new polinomial.</returns>
        public static Polynomial Substract(Polynomial lhs, double number)
        {
            return Add(lhs, -number);
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
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            if (ReferenceEquals(rhs, null))
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            double[] array = new double[lhs.Degree + 1 + rhs.Degree + 1];
            for (int i = 0; i < lhs.Degree + 1; i++)
            {
                for (int j = 0; j < rhs.Degree + 1; j++)
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
            if (ReferenceEquals(lhs, null))
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            double[] array = new double[lhs.Degree + 1];
            for (int i = 0; i < lhs.Degree + 1; i++)
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
            if (lhs.Degree != rhs.Degree)
            {
                return false;
            }
            for (int i = 0; i < lhs.Degree + 1; i++)
            {
                if (lhs.coefficients[i] != rhs.coefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Override method Equals of System.Object. Cheks the equality of two polynomials.
        /// </summary>
        /// <param name="rhs">Polynomial.</param>
        /// <returns>True if polynomials equal.</returns>
        public override bool Equals(object rhs)
        {
            Polynomial polinomial = rhs as Polynomial;

            if (polinomial.Degree != this.Degree)
            {
                return false;
            }

            for (int i = 0; i < polinomial.Degree + 1; i++)
            {
                if (polinomial.coefficients[i] != this.coefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// /// Override method ToString() of System.Object.
        /// </summary>
        /// <returns>String representation of the polynomial.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = Degree; i >= 0; i--)
            {
                result.AppendFormat("{0}{1}{2}", coefficients[i] > 0 ? "+" : "", coefficients[i] != 0 && i != 0 ? (coefficients[i]) + "x^" + i : "", i == 0 ? coefficients[i] + "=0" : "");
            }
            return result.ToString();
        }

        /// <summary>
        /// /// Override method GetHashCode() of System.Object.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
