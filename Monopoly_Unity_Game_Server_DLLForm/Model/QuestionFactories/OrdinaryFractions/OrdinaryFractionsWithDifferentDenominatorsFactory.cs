using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.OrdinaryFractions
{
    public class OrdinaryFractionsWithDifferentDenominatorsFactory : IQuestionFactory
    {
        public OrdinaryFractionsWithDifferentDenominatorsFactory(Random random)
        {
            _random = random;
        }


        private Random _random;


        private List<int> FindAllDividers(int number)
        {
            List<int> dividers = new List<int>();
            for (int i = 1; i * i < number; i++)
                if (number % i == 0) dividers.AddRange(new int[] { i, number / i });
            return dividers;
        }

        private List<int> FindAllDivisibles(int number, int maxDivisible)
        {
            List<int> divisibles = new List<int>();
            for (int i = 1; i <= maxDivisible; i++)
                if(i % number == 0) divisibles.Add(i);
            return divisibles;
        }

        public Question GetQuestion()
        {
            Question question = new Question();
            List<int>? fractionDividers = null;
            int fractionSum = 0;
            do
            {
                fractionSum = _random.Next(1, 31);
                fractionDividers = FindAllDividers(fractionSum);
            } while (fractionDividers.Count <= 2);

            int firstDivider = fractionDividers[_random.Next(2, fractionDividers.Count)];
            fractionDividers.Remove(firstDivider);
            int secondDivider = fractionDividers[_random.Next(2, fractionDividers.Count)];

            List<int> firstDividerPossibleDivisibles = FindAllDivisibles(fractionSum / firstDivider, 1000).Intersect(FindAllDivisibles(fractionSum, 1000)).ToList();
            List<int> secondDividerPossibleDivisibles = FindAllDivisibles(fractionSum / secondDivider, 1000).Intersect(FindAllDivisibles(fractionSum, 1000)).ToList();

            int firstDividerDivisible = firstDividerPossibleDivisibles[_random.Next(0, firstDividerPossibleDivisibles.Count)];
            int secondDividerDivisible = secondDividerPossibleDivisibles[_random.Next(0, secondDividerPossibleDivisibles.Count)];

            Example firstExamplePart = new ExampleWithTwoArguments
                ( new SimpleNumberAsExample(firstDividerDivisible / (fractionSum / firstDivider)),
                  new SimpleNumberAsExample(firstDivider),
                  ActionType.Division );
            Example secondExamplePart = new ExampleWithTwoArguments
                ( new SimpleNumberAsExample(secondDividerDivisible / (fractionSum / secondDivider)),
                  new SimpleNumberAsExample(secondDivider),
                  ActionType.Division );

            Example finalExample;

            switch (_random.Next(0, 2))
            {
                case 0:
                    finalExample = new ExampleWithTwoArguments(firstExamplePart, secondExamplePart, ActionType.Addition);

                    question.Answers = new string[] { ((double)(firstDividerDivisible + secondDividerDivisible) / fractionSum).ToString() };
                    question.QuestionText = finalExample.ExampleInString();
                    break;
                case 1:
                    finalExample = new ExampleWithTwoArguments(firstExamplePart, secondExamplePart, ActionType.Subtraction);

                    question.Answers = new string[] { ((double)(firstDividerDivisible - secondDividerDivisible) / fractionSum).ToString() };
                    question.QuestionText = finalExample.ExampleInString();
                    break;
            }

            

            return question;
        }
    }
}
