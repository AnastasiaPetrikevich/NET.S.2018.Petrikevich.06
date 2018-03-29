using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Polynomial;

namespace Plynomial.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(1, 0, -3, 4, ExpectedResult = "+4x^3-3x^2+1=0")]
        [TestCase(1, 2, 3, 4, ExpectedResult = "+4x^3+3x^2+2x^1+1=0")]
        public string Polynomials_ToString(params double[] array)
        {
            Polynomial.Polynomial polynomial = new Polynomial.Polynomial(array);
            return polynomial.ToString();
        }

        [TestCase(ExpectedResult = "+1x^3+3x^2+2x^1+3=0")]
        public string Add_Two_Polynomials()
        {
            Polynomial.Polynomial first = new Polynomial.Polynomial(2, 0, 2);
            Polynomial.Polynomial second = new Polynomial.Polynomial(1, 2, 1, 1);
            Polynomial.Polynomial result = Polynomial.Polynomial.Add(first, second);
            return result.ToString();
        }

        [TestCase(2.5, ExpectedResult = "+2x^2+4,5=0")]
        public string Add_Polynomial_With_Number(double number)
        {
            Polynomial.Polynomial first = new Polynomial.Polynomial(2, 0, 2);
            Polynomial.Polynomial result = Polynomial.Polynomial.Add(first, number);
            return result.ToString();
        }

        [TestCase(ExpectedResult = "+4x^2-4=0")]
        public string Multiply_Two_Polynomials()
        {
            Polynomial.Polynomial first = new Polynomial.Polynomial(2, 2);
            Polynomial.Polynomial second = new Polynomial.Polynomial(-2, 2);
            Polynomial.Polynomial result = first * second;
            return result.ToString();
        }

        [TestCase(2.5, ExpectedResult = "+5x^2+5=0")]
        public string Multiply_Polynomial_With_Number(double number)
        {
            Polynomial.Polynomial first = new Polynomial.Polynomial(2, 0, 2);
            Polynomial.Polynomial result = Polynomial.Polynomial.Multiply(first, number);
            return result.ToString();
        }

        [TestCase(ExpectedResult = "-1x^3+1x^2-2x^1+1=0")]
        public string Substract_Two_Polynomials()
        {
            Polynomial.Polynomial first = new Polynomial.Polynomial(2, 0, 2);
            Polynomial.Polynomial second = new Polynomial.Polynomial(1, 2, 1, 1);
            Polynomial.Polynomial result = first - second;
            return result.ToString();
        }

        [TestCase(1, ExpectedResult = "+2x^2-1=0")]
        public string Substract_Polynomial_With_Number(double number)
        {
            Polynomial.Polynomial first = new Polynomial.Polynomial(2, 0, 2);
            Polynomial.Polynomial result = Polynomial.Polynomial.Add(first, number);
            return result.ToString();
        }

        [TestCase(ExpectedResult = true)]
        public bool IsEquals_Two_Polynomials()
        {
            Polynomial.Polynomial first = new Polynomial.Polynomial(2, 1, 2);
            Polynomial.Polynomial second = new Polynomial.Polynomial(2, 1, 2);

            return first == second;
        }

        [TestCase(ExpectedResult = true)]
        public bool IsNotEquals_Two_Polynomials()
        {
            Polynomial.Polynomial first = new Polynomial.Polynomial(2, 1, 2, 5);
            Polynomial.Polynomial second = new Polynomial.Polynomial(2, 1, 2);

            return first != second;
        }
    }
}
