namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.DegreeQuestion
{
    public class DegreeWithNaturalExponentFactory : IQuestionFactory
    {
        public DegreeWithNaturalExponentFactory(Random random) 
        {
            _random = random;
        }


        private Random _random;


        public Question GetQuestion()
        {
            Question question = new Question();

            double degreeBase = _random.Next(1, 30);

            Example finalExample = new ExampleWithTwoArguments(new SimpleNumberAsExample(degreeBase), GetExponent(degreeBase), ActionType.Exponentiation);

            question.QuestionText = finalExample.ExampleInString();
            question.Answers = [finalExample.GetExampleResult()];

            return question;
        }

        public Example GetExponent(double degreeBase)
        {
            double exponentResult;

            if (degreeBase <= 2)
                exponentResult = _random.Next(0, 11);
            else if (degreeBase <= 5)
                exponentResult = _random.Next(0, 6);
            else
                exponentResult = _random.Next(0, 3);

            Example FirstNumber = new SimpleNumberAsExample(_random.Next(-20, 21));
            Example SecondNumber = new SimpleNumberAsExample(0);
            ActionType actionType = (ActionType)_random.Next(0, 2);

            switch (actionType)
            {
                case ActionType.Addition: SecondNumber = new SimpleNumberAsExample(exponentResult - Convert.ToDouble(FirstNumber.GetExampleResult())); break;
                case ActionType.Subtraction: SecondNumber = new SimpleNumberAsExample(Convert.ToDouble(FirstNumber.GetExampleResult()) - exponentResult); break;
            }

            return new ExampleWithTwoArguments(FirstNumber, SecondNumber, actionType);
        }
    }
}
