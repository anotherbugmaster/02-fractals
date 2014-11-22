using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace fractals
{
    public class Polynom
    {
        private List<Double> coefficients;
        private Complex freeCoefficient;

        public static void Main(string[] args)
        {
            
        }
        public Polynom(List<Double> coefficients, Complex freeCoef)
        {
            this.coefficients = coefficients;
            freeCoefficient = freeCoef;
        }

        public Polynom(int power, Complex freeCoef)
        {
            coefficients = Enumerable
                .Range(0, power)
                .Select(z => 0.0)
                .ToList();
            coefficients[power - 1] = 1;
            freeCoefficient = freeCoef;
        }

        public Complex GetValue(Complex c)
        {
            var result = new Complex();
            var power = c;
            foreach (var coef in coefficients)
            {
                result += coef*power;
                power *= c;
            }
            result += freeCoefficient;
            return result;
        }
    }

    public class FractalGen
    {

        private static bool isFractalPoint(Complex complex, Polynom function, double border)
        {
            var iterations = 50;
            var z = function.GetValue(complex);
            for (var i = 0; i < iterations; i++)
            {
                if (z.Magnitude >= border)
                    return false;
                z = function.GetValue(z);
            }
            return true;
        }

        public static IEnumerable<Complex> getFractalComplexes(Polynom function)
        {
            double border = 2;
            double step = 0.01;
            for (var x = -border; x <= border; x += step)
                for (var y = -border; y <= border; y += step)
                {
                    var complex = new Complex(x, y);
                    if (isFractalPoint(complex, function, border))
                        yield return complex;
                }
        }
    }


}
