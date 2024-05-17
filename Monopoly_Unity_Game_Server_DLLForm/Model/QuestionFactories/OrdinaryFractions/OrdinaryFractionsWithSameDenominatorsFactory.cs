namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.OrdinaryFractions
{
    public class OrdinaryFractionsWithSameDenominatorsFactory : IQuestionFactory
    {
        public OrdinaryFractionsWithSameDenominatorsFactory(Random random)
        {
            _random = random;
        }


        private Random _random;


        private List<int> FindAllDividers(int number)
        {
            List<int> divioners = new List<int>();
            for (int i = 1; i * i < number; i++)
                if (number % i == 0) divioners.AddRange([i, number / i]);
            return divioners;
        }

        public Question GetQuestion()
        {
            Question question = new Question();
            double sum;
            List<int> dividers;
            ActionType action = (ActionType)_random.Next(0, 2);

            do
            {
                sum = _random.Next(0, 1000);
                dividers = FindAllDividers((int)sum);

            } while (dividers.Count == 2);

            double fraction = dividers[_random.Next(2, dividers.Count)];

            double aArg = _random.Next(0, 1000);
            double bArg = 0;
            switch (action)
            {
                case ActionType.Addition:
                    bArg = sum - aArg;
                    break;
                case ActionType.Subtraction:
                    bArg = aArg - sum;
                    break;
            }

            Example firstPart = new ExampleWithTwoArguments(new SimpleNumberAsExample(aArg), new SimpleNumberAsExample(fraction), ActionType.Division);
            Example secondPart = new ExampleWithTwoArguments(new SimpleNumberAsExample(bArg), new SimpleNumberAsExample(fraction), ActionType.Division);
            Example? finalPart = null;
            switch (action)
            {
                case ActionType.Addition:
                    finalPart = new UserExample(sum / fraction, new ExampleWithTwoArguments(firstPart, secondPart, ActionType.Addition).ExampleInString());
                    break;
                case ActionType.Subtraction:
                    finalPart = new UserExample(sum / fraction, new ExampleWithTwoArguments(firstPart, secondPart, ActionType.Subtraction).ExampleInString());
                    break;
            }

            question.Answers = [finalPart!.GetExampleResult()];
            question.QuestionText = finalPart.ExampleInString();

            return question;
        }
    }
}
