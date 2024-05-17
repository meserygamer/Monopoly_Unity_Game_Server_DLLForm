using System.Collections;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.RootQuestion
{
    public class CalculateRoot2And3Factory : IQuestionFactory
    {
        public CalculateRoot2And3Factory(Random random)
        {
            _random = random;

            _listForSquareRoot = new List<double>();
            foreach (var i in Enumerable.Range(1, 20))
            {
                _listForSquareRoot.Add(Math.Pow(i, 2));
            }

            _listForCubeRoot = new List<double>();
            foreach (var i in Enumerable.Range(-10, 21))
            {
                _listForCubeRoot.Add(Math.Pow(i, 3));
            }
        }

        private List<double>? _listForSquareRoot = null;
        private List<double>? _listForCubeRoot = null;


        private Random _random;


        public Question GetQuestion()
        {
            Question question = new Question();
            Example example = null;

            switch (_random.Next(0, 2))
            {
                case 0:
                    example = new ExampleWithTwoArguments(new SimpleNumberAsExample(2), new SimpleNumberAsExample(_listForSquareRoot[_random.Next(0, _listForSquareRoot.Count)]), ActionType.TakingRoot);break;
                case 1:
                    example = new ExampleWithTwoArguments(new SimpleNumberAsExample(3), new SimpleNumberAsExample(_listForCubeRoot[_random.Next(0, _listForSquareRoot.Count)]), ActionType.TakingRoot); break;
            }

            question.QuestionText = example.ExampleInString();
            question.Answers = [example.GetExampleResult()];
            return question;
        }
    }
}
