using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.OrdinaryFractions
{
    public class OrdinaryFractionsWithTwoActionsFactory : IQuestionFactory
    {
        public OrdinaryFractionsWithTwoActionsFactory(Random random)
        {
            _random = random;
        }


        private Random _random;


        private List<int> FindAllDividers(int number)
        {
            List<int> dividers = new List<int>();
            for (int i = 1; i * i < number; i++)
                if (number % i == 0) dividers.AddRange([i, number / i]);
            return dividers;
        }

        private List<int> FindAllDivisibles(int number, int maxDivisible)
        {
            List<int> divisibles = new List<int>();
            for (int i = 1; i <= maxDivisible; i++)
                if(i % number == 0) divisibles.Add(i);
            return divisibles;
        }

        private ExampleWithTwoArguments GenerateOrdinaryFractionsExampleWithDifferentDenominators(ActionType actionType, out int denominatorResult, out int numeratorResult)
        {
            List<int>? denominatorDividers;
            do
            {
                denominatorResult = _random.Next(1, 31);
                denominatorDividers = FindAllDividers(denominatorResult);
            } while (denominatorDividers.Count <= 2);

            int firstDivider = denominatorDividers[_random.Next(2, denominatorDividers.Count)];
            denominatorDividers.Remove(firstDivider);
            int secondDivider = denominatorDividers[_random.Next(2, denominatorDividers.Count)];

            List<int> firstDividerPossibleDivisibles = FindAllDivisibles(denominatorResult / firstDivider, 1000).Intersect(FindAllDivisibles(denominatorResult, 1000)).ToList();
            List<int> secondDividerPossibleDivisibles = FindAllDivisibles(denominatorResult / secondDivider, 1000).Intersect(FindAllDivisibles(denominatorResult, 1000)).ToList();

            int firstDividerDivisible = firstDividerPossibleDivisibles[_random.Next(0, firstDividerPossibleDivisibles.Count)];
            int secondDividerDivisible = secondDividerPossibleDivisibles[_random.Next(0, secondDividerPossibleDivisibles.Count)];

            numeratorResult = (actionType == ActionType.Addition) ? firstDividerDivisible + secondDividerDivisible : firstDividerDivisible - secondDividerDivisible;

            ExampleWithTwoArguments firstExamplePart = new ExampleWithTwoArguments
                (new SimpleNumberAsExample(firstDividerDivisible / (denominatorResult / firstDivider)),
                  new SimpleNumberAsExample(firstDivider),
                  ActionType.Division);
            ExampleWithTwoArguments secondExamplePart = new ExampleWithTwoArguments
                (new SimpleNumberAsExample(secondDividerDivisible / (denominatorResult / secondDivider)),
                  new SimpleNumberAsExample(secondDivider),
                  ActionType.Division);

            return new ExampleWithTwoArguments(firstExamplePart, secondExamplePart, actionType);
        }

        private ExampleWithTwoArguments GenerateOrdinaryFractions(int numeratorFirstPart, int denominator, ActionType actionWithFirstPart, out int numerator)
        {
            List<int> denominatorsDivisibles = FindAllDivisibles(denominator, 1000);
            int denominatorsDivisible = denominatorsDivisibles[_random.Next(0, denominatorsDivisibles.Count)];
            
            switch(actionWithFirstPart)
            {
                case ActionType.Addition:
                    numerator = denominatorsDivisible - numeratorFirstPart;
                    break;
                case ActionType.Subtraction:
                    numerator = numeratorFirstPart - denominatorsDivisible;
                    break;
                default: throw new NotImplementedException();
            }

            return new ExampleWithTwoArguments(new SimpleNumberAsExample(numerator), new SimpleNumberAsExample(denominator), ActionType.Division);
        }

        public Question GetQuestion()
        {
            Question question = new Question();

            ActionType firstPartAction = (ActionType)_random.Next(0, 2);
            ExampleWithTwoArguments firstExamplePart = 
                GenerateOrdinaryFractionsExampleWithDifferentDenominators(firstPartAction, out int firstPartDenominatorResult, out int firstPartNumeratorResult);
            ActionType secondPartAction = (ActionType)_random.Next(0, 2);
            ExampleWithTwoArguments SecondPart = GenerateOrdinaryFractions(firstPartNumeratorResult, firstPartDenominatorResult, secondPartAction, out int secondPartNumerator);
            double numeratorResult = (secondPartAction == ActionType.Addition) ? (double)(firstPartNumeratorResult + secondPartNumerator) : (double)(firstPartNumeratorResult - secondPartNumerator);
            UserExample finalExample = new UserExample(numeratorResult / firstPartDenominatorResult, new ExampleWithTwoArguments(firstExamplePart, SecondPart, secondPartAction).ExampleInString());

            question.Answers = [finalExample.GetExampleResult()];
            question.QuestionText = finalExample.ExampleInString();

            return question;
        }
    }
}
