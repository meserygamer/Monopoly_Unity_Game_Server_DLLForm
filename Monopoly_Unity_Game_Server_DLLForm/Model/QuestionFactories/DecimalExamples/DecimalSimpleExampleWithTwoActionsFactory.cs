using System;
using System.Collections.Generic;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.DecimalExamples
{
    public class DecimalSimpleExampleWithTwoActionsFactory : IQuestionFactory
    {
        public DecimalSimpleExampleWithTwoActionsFactory(Random random)
        {
            _random = random;
        }


        private Random _random;


        private decimal GenerateDecimal(int maxBase, int offsetDigitsRight, out int decimalBase)
        {
            decimalBase = _random.Next(1, maxBase + 1);
            return (decimal)decimalBase / (decimal)Math.Pow(10, offsetDigitsRight);
        }

        private decimal GenerateDecimal(int maxBase, int offsetDigitsRight) => 
            (decimal)_random.Next(1, maxBase + 1) / (decimal)Math.Pow(10, offsetDigitsRight);

        private List<int> FindAllDividers(int number)
        {
            List<int> dividers = new List<int>();
            for (int i = 1; i * i <= number; i++)
                if (number % i == 0) dividers.AddRange(new List<int>() { i, number / i });
            return dividers;
        }

        private Example GenerateSimplyMultiplyExample()
        {
            decimal firstNumber = GenerateDecimal(9, 1, out int firstNumberBase);
            decimal secondNumber = GenerateDecimal(9, 1, out int secondNumberBase);

            return new ExampleWithTwoArguments(new SimpleNumberAsExample((double)firstNumber), new SimpleNumberAsExample((double)secondNumber), ActionType.Multiplication);
        }

        private Example GenerateSimplyDivisionExample()
        {
            decimal firstNumber = GenerateDecimal(100, 2, out int firstNumberBase);
            List<int> firstNumberBaseDeividers = FindAllDividers(firstNumberBase);
            if(!firstNumberBaseDeividers.Contains(2))
                firstNumberBaseDeividers.Add(2);
            decimal secondNumber = (decimal)firstNumberBaseDeividers[_random.Next(0, firstNumberBaseDeividers.Count)] / (decimal)Math.Pow(10, _random.Next(1,3));

            return new ExampleWithTwoArguments(new SimpleNumberAsExample((double)firstNumber), new SimpleNumberAsExample((double)secondNumber), ActionType.Division);
        }

        private Example GenerateSimplyAdditionExample() 
        {
            decimal firstNumber = GenerateDecimal(10000, 2, out int firstNumberBase);
            decimal secondNumber = GenerateDecimal(10000, 2, out int secondNumberBase);

            return new ExampleWithTwoArguments(new SimpleNumberAsExample((double)firstNumber), new SimpleNumberAsExample((double)secondNumber), ActionType.Addition);
        }

        private Example GenerateSimplySubtractExample()
        {
            decimal firstNumber = GenerateDecimal(10000, 2, out int firstNumberBase);
            decimal secondNumber = GenerateDecimal(10000, 2, out int secondNumberBase);

            return new ExampleWithTwoArguments(new SimpleNumberAsExample((double)firstNumber), new SimpleNumberAsExample((double)secondNumber), ActionType.Subtraction);
        }

        public Question GetQuestion()
        {
            Question question = new Question();

            Example? firstPartExample = null;

            switch (_random.Next(0, 4))
            {
                case 0:
                    firstPartExample = GenerateSimplyAdditionExample();
                    break; 
                case 1:
                    firstPartExample = GenerateSimplySubtractExample();
                    break;
                case 2:
                    firstPartExample = GenerateSimplyMultiplyExample();
                    break;
                case 3:
                    firstPartExample = GenerateSimplyDivisionExample();
                    break;
            }

            Example? finalExample = null;

            finalExample =
                        new ExampleWithTwoArguments(firstPartExample, new SimpleNumberAsExample((double)GenerateDecimal(10000, 2)), (ActionType)_random.Next(0, 2));

            question.Answers = new string[] { finalExample.GetExampleResult() };
            question.QuestionText = finalExample.ExampleInString();

            return question;
        }
    }
}
