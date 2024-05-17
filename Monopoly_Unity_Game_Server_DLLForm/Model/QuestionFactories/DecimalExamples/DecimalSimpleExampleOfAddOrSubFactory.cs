namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.DecimalExamples
{
    public class DecimalSimpleExampleOfAddOrSubFactory : IQuestionFactory
    {
        public DecimalSimpleExampleOfAddOrSubFactory(Random random)
        {
            _random = random;
        }


        private Random _random;


        private decimal GenerateDecimal() => (decimal)_random.Next(1, 10001) / 100;


        public Question GetQuestion()
        {
            Question question = new Question();

            decimal firstNumber = GenerateDecimal();
            decimal secondNumber = GenerateDecimal();

            ExampleWithTwoArguments example =
                new ExampleWithTwoArguments(new SimpleNumberAsExample((double)firstNumber), new SimpleNumberAsExample((double) secondNumber), (ActionType)_random.Next(0, 2));

            question.Answers = [example.GetExampleResult()];
            question.QuestionText = example.ExampleInString();

            return question;
        }
    }
}
