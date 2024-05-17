namespace Monopoly_Unity_Game_Server.Model.QuestionFactories
{
    public class QuadraticEquationWithA1QuestionFactory : IQuestionFactory
    {
        public QuadraticEquationWithA1QuestionFactory(Random random) 
        { 
            _random = random;
        }


        private readonly double[] POSSIBLE_DISCRIMINANT_VALUES = [0, 1, 4, 9, 16, 25, 36, 49, 64, 81, 100];


        private Random _random;


        public Question GetQuestion()
        {
            Question question = new Question();

            GenerateQuadraticEquationArguments(out double bArgument, out double cArgument);

            question.QuestionText = GenerateQuadraticEquationString(bArgument, cArgument);
            question.Answers = CalculateQuadraticEquationResult(bArgument, cArgument);

            return question;
        }

        private void GenerateQuadraticEquationArguments(out double bArgument, out double cArgument)
        {
            bArgument = _random.Next(-10, 11);
            double Discriminant = POSSIBLE_DISCRIMINANT_VALUES[_random.Next(0, POSSIBLE_DISCRIMINANT_VALUES.Length)];
            cArgument = (Math.Pow(bArgument, 2) - Discriminant) / 4;
        }

        private string GenerateQuadraticEquationString(double bArgument, double cArgument) => "x^2 + " + bArgument + "x + " + cArgument + " = 0";

        private string[] CalculateQuadraticEquationResult(double bArgument, double cArgument)
        {
            string[] result;
            double Discimenant = Math.Pow(bArgument, 2) - 4 * cArgument;
            if (Discimenant == 0)
                result = new string[]
                {
                    (-bArgument / 2).ToString()
                };
            else
                result = new string[]
                {
                    ((-bArgument + Math.Sqrt(Discimenant)) / 2).ToString(),
                    ((-bArgument - Math.Sqrt(Discimenant)) / 2).ToString()
                };
            return result;
        }
    }
}
