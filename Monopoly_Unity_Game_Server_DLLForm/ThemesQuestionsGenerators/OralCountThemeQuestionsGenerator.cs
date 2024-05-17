using Monopoly_Unity_Game_Server.Model;

namespace Monopoly_Unity_Game_Server.ControlThemesQuestionsGenerators
{
    public class OralCountThemeQuestionsGenerator
    {
        public OralCountThemeQuestionsGenerator()
        {
            Random random = new Random();
            _singleActionQuestionFactory = new SingleActionQuestionFactory(random);
            _doubleActionQuestionFactory = new DoubleActionQuestionFactory(random);
        }


        private SingleActionQuestionFactory _singleActionQuestionFactory;
        private DoubleActionQuestionFactory _doubleActionQuestionFactory;


        public GameSquareExample GenerateExampleWithSingleAction()
        {
            Question question = _singleActionQuestionFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 10 };
        }

        public GameSquareExample GenerateExampleWithDoubleAction()
        {
            Question question = _doubleActionQuestionFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 18 };
        }
    }
}
