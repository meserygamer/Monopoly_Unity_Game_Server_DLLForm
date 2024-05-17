namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.DecimalExamples
{
    public class DecimalSimpleExampleOfMulOrDivFactory : IQuestionFactory
    {
        public DecimalSimpleExampleOfMulOrDivFactory(Random random)
        {
            _random = random;
        }


        private Random _random;


        private decimal GenerateDecimal(int maxBase, int offsetDigitsRight, out int decimalBase)
        {
            decimalBase = _random.Next(1, maxBase + 1);
            return (decimal)decimalBase / (decimal)Math.Pow(10, offsetDigitsRight);
        }

        private List<int> FindAllDividers(int number)
        {
            List<int> dividers = new List<int>();
            for (int i = 1; i * i <= number; i++)
                if (number % i == 0) dividers.AddRange([i, number / i]);
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

        public Question GetQuestion()
        {
            Question question = new Question();

            Example? example = null;
            switch(_random.Next(0,2))
            {
                case 0:
                    example = GenerateSimplyDivisionExample();
                    break;
                case 1:
                    example = GenerateSimplyMultiplyExample();
                    break;
            }
             

            question.Answers = [example.GetExampleResult()];
            question.QuestionText = example.ExampleInString();

            return question;
        }
    }
}
