using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.RootQuestion;
using System;

namespace Monopoly_Unity_Game_Server.ControlThemesQuestionsGenerators
{
    public class RootQuestionThemeQuestionsGenerator
    {
        public RootQuestionThemeQuestionsGenerator()
        {
            Random random = new Random();
            _calculateRoot2And3Factory = new CalculateRoot2And3Factory(random);
            _propertiesOfRootFactory = new PropertiesOfRootFactory(random);
        }


        private CalculateRoot2And3Factory _calculateRoot2And3Factory;
        private PropertiesOfRootFactory _propertiesOfRootFactory;


        public GameSquareExample CalculateRoot2And3() 
        {
            Question question = _calculateRoot2And3Factory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 10 };
        }

        public GameSquareExample PropertiesOfRoot()
        {
            Question question = _propertiesOfRootFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

        public GameSquareExample ActionsWithRoot()
        {
            Question question = _propertiesOfRootFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 25 };
        }

    }
}
