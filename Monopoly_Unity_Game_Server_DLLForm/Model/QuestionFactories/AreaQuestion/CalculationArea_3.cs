using Monopoly_Unity_Game_Server.Model.AreaQuestion;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.AreaQuestion.FiguresAreas;

namespace Monopoly_Unity_Game_Server.Model
{
    public class CalculationArea_3 : IQuestionFactory
    {
        public CalculationArea_3(Random random)
        {
            _random = random;
            _PossibleFigures = new List<IFigureAreaQuestion>
            {
                new AreaTriangleThroughtGeron(_random),
                new AreaTrapezoid(_random),
            };
        }


        private Random _random;

        private readonly List<IFigureAreaQuestion> _PossibleFigures;


        public Question GetQuestion()
        {
            Question question = new Question();

            IFigureAreaQuestion figureArea = _PossibleFigures[_random.Next(0, _PossibleFigures.Count)];
            figureArea.GenerateFigure();
            question.QuestionText = figureArea.QuestionText;
            question.Answers = [figureArea.FigureArea.ToString()];

            return question;
        }
    }
}
