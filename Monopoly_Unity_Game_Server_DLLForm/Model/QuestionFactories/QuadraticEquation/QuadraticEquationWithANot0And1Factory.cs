using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories
{
    public class QuadraticEquationWithANot0And1Factory : IQuestionFactory
    {
        public QuadraticEquationWithANot0And1Factory(Random random)
        {
            _random = random;
            _possibleDicriminantValues = FindAllNumbersSquares(20);
        }


        private List<int> _possibleDicriminantValues;


        private Random _random;


        public Question GetQuestion()
        {
            Question question = new Question();

            double aArgument, bArgument, cArgument;
            double discrimenant = _possibleDicriminantValues[_random.Next(0, _possibleDicriminantValues.Count)];
            do
            {
                bArgument = _random.Next(0, 20);
            }
            while (Math.Pow(bArgument, 2) == discrimenant);
            double discrimenantSecondPart = -(discrimenant - Math.Pow(bArgument, 2));
            double aArgumentMultiplycArgument = Math.Round(discrimenantSecondPart / 4, 3);
            List<double> listPossibleDividers = FindAllDividers(aArgumentMultiplycArgument);
            List<double> temporaryList = new List<double>();
            listPossibleDividers.ForEach(a => temporaryList.Add(a*2));
            List<double> temp1 = FindAllDividers(-bArgument + Math.Sqrt(discrimenant), temporaryList.ToArray());
            List<double> temp2 = FindAllDividers(-bArgument - Math.Sqrt(discrimenant), temporaryList.ToArray());
            List<double> possibleAValues = temp1.Intersect(temp2).ToList();
            possibleAValues.Remove(1 * 2);
            possibleAValues.Remove(0 * 2);
            aArgument = possibleAValues[_random.Next(0, possibleAValues.Count)] / 2;
            cArgument = aArgumentMultiplycArgument / aArgument;

            question.QuestionText = GenerateQuadraticEquationString(aArgument, bArgument, cArgument);
            question.Answers = CalculateQuadraticEquationResult(aArgument, bArgument, discrimenant);

            return question;
        }

        private string GenerateQuadraticEquationString(double aArgument, double bArgument, double cArgument) => 
            aArgument + "x^2" + ((bArgument != 0)? $" + {bArgument}x" : "") + ((cArgument != 0) ? $" + {cArgument}" : "") + " = 0";

        private string[] CalculateQuadraticEquationResult(double aArgument, double bArgument, double discriminant)
        {
            string[] result;
            double x1;
            double x2;
            if (discriminant == 0)
                result = new string[]
                {
                    (-bArgument / (2 * aArgument)).ToString()
                };
            else
            {
                x1 = (-bArgument + Math.Sqrt(discriminant)) / (2 * aArgument);
                x2 = (-bArgument - Math.Sqrt(discriminant)) / (2 * aArgument);
                result = new string[]
                {
                    x1.ToString(),
                    x2.ToString()
                };
            } 
            return result;
        }

        private List<int> FindAllNumbersSquares(int maxNumber)
        {
            List<int> allSquares = new List<int>();
            for (int i = 0; i < maxNumber; i++)
                allSquares.Add(i * i);
            return allSquares;
        }

        private List<double> FindAllDividers(double number)
        {
            List<double> dividers = new List<double>();
            List<double> possibleOst = new List<double>() { 0, 0.25d, 0.5d, 0.75d, -0d, -0.25d, -0.5d, -0.75d };
            for (int i = 1; i * i < Math.Abs(number); i++)
                if (number % i == 0) dividers.AddRange(new double[] { i, number / i });
            for (int i = 0; i < Math.Abs(number); i++)
            {
                if (i != 0 && possibleOst.Contains(number / i % 1d) && !dividers.Contains(i))
                    dividers.AddRange(new double[] { i, number / i });
                if (number % (i + 0.25d) == 0d || possibleOst.Contains(number / (i + 0.25d) % 1d))
                    dividers.AddRange(new double[] { i + 0.25d, number / (i + 0.25d) });
                if (number % (i + 0.5d) == 0d || possibleOst.Contains(number / (i + 0.5d) % 1d))
                    dividers.AddRange(new double[] { i + 0.5d, number / (i + 0.5d) });
                if (number % (i + 0.75d) == 0d || possibleOst.Contains(number / (i + 0.75d) % 1d))
                    dividers.AddRange(new double[] { i + 0.75d, number / (i + 0.75d) });
            }
            return dividers;
        }

        private List<double> FindAllDividers(double number, double[] possibleDividers)
        {
            List<double> dividers = new List<double>();
            List<double> possibleOst = new List<double> { 0, 0.25d, 0.5d, 0.75d, -0d, -0.25d, -0.5d, -0.75d };
            foreach (var i in possibleDividers)
                if(number % i == 0 || possibleOst.Contains((number / i) % 1)) dividers.Add(i);
            return dividers;
        }
    }
}
