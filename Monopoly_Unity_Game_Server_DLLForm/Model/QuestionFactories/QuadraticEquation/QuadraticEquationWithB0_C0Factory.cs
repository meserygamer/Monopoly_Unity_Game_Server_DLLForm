using System;
using System.Collections.Generic;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories
{
    public class QuadraticEquationWithB0_C0Factory : IQuestionFactory
    {
        public QuadraticEquationWithB0_C0Factory(Random random)
        {
            _random = random;
            _possibleDicriminantValues = FindAllNumbersSquares(30);
        }


        private List<int> _possibleDicriminantValues;


        private Random _random;


        public Question GetQuestion()
        {
            Question question = new Question();

            double aArgument, bArgument, cArgument;
            if (_random.Next(0, 2) == 0)
                GenerateQuadraticEquationArgs_B0(out aArgument, out bArgument, out cArgument);
            else
                GenerateQuadraticEquationArgs_C0(out aArgument, out bArgument, out cArgument);

            question.QuestionText = GenerateQuadraticEquationString(aArgument, bArgument, cArgument);
            question.Answers = CalculateQuadraticEquationResult(aArgument, bArgument, cArgument);

            return question;
        }

        private void GenerateQuadraticEquationArgs_B0(out double aArgument, out double bArgument, out double cArgument)
        {
            double discriminant = _possibleDicriminantValues[_random.Next(1, _possibleDicriminantValues.Count)];
            bArgument = 0;
            double discrimenantSecondPart = -discriminant;
            double aArgumentMultiplycArgument = Math.Round(discrimenantSecondPart / 4, 3);
            List<double> listPossibleDividers = FindAllDividers(aArgumentMultiplycArgument);
            List<double> temporaryList = new List<double>();
            listPossibleDividers.ForEach(a => temporaryList.Add(a * 2));
            List<double> temp1 = FindAllDividers(Math.Sqrt(discriminant), temporaryList.ToArray());
            temp1.Remove(1 * 2);
            temp1.Remove(0 * 2);
            aArgument = temp1[_random.Next(0, temp1.Count)] / 2;
            cArgument = aArgumentMultiplycArgument / aArgument;
        }

        private void GenerateQuadraticEquationArgs_C0(out double aArgument, out double bArgument, out double cArgument)
        {
            double discriminant = _possibleDicriminantValues[_random.Next(1, _possibleDicriminantValues.Count)];
            bArgument = Math.Sqrt(discriminant);
            cArgument = 0;
            List<double> possibleAarguments = FindAllDividers((int)bArgument);
            aArgument = possibleAarguments[_random.Next(0, possibleAarguments.Count)];
        }

        private string GenerateQuadraticEquationString(double aArgument, double bArgument, double cArgument) =>
            aArgument + "x^2" + ((bArgument != 0) ? $" + {bArgument}x" : "") + ((cArgument != 0) ? $" + {cArgument}" : "") + " = 0";

        private string[] CalculateQuadraticEquationResult(double aArgument, double bArgument, double cArgument)
        {
            string[] result;
            double Discimenant = Math.Pow(bArgument, 2) - 4 * aArgument * cArgument;
            if (Discimenant == 0)
                result = new string[]
                {
                    (-bArgument / (2 * aArgument)).ToString()
                };
            else
                result = new string[]
                {
                    ((-bArgument + Math.Sqrt(Discimenant)) / (2 * aArgument)).ToString(),
                    ((-bArgument - Math.Sqrt(Discimenant)) / (2 * aArgument)).ToString()
                };
            return result;
        }

        private List<int> FindAllNumbersSquares(int maxNumber)
        {
            List<int> allSquares = new List<int>();
            for (int i = 0; i < maxNumber; i++)
                allSquares.Add(i * i);
            return allSquares;
        }

        private List<double> FindAllDividers(int number)
        {
            List<double> dividers = new List<double>();
            for (int i = 1; i * i <= Math.Abs(number); i++)
                if (number % i == 0) dividers.AddRange(new double[] { i, number / i });
            return dividers;
        }

        private List<double> FindAllDividers(double number)
        {
            List<double> dividers = new List<double>();
            List<double> possibleOst = new List<double> { 0, 0.25d, 0.5d, 0.75d, -0d, -0.25d, -0.5d, -0.75d };
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
                if (number % i == 0 || possibleOst.Contains((number / i) % 1)) dividers.Add(i);
            return dividers;
        }
    }
}
