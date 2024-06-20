using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.DegreeQuestion;
using System;

namespace Monopoly_Unity_Game_Server.ThemesQuestionsGenerators
{
    public class DegreeThemeQuestionsGenerator
    {
        public DegreeThemeQuestionsGenerator() 
        {
            Random random = new Random();
            _degreeWithNaturalExponentFactory = new DegreeWithNaturalExponentFactory(random);
            _propertiesOfDegreesFactory = new PropertiesOfDegreesFactory(random);
            _propertiesOfDegreesWith0AndNegativeFactory = new PropertiesOfDegreesWith0andNegativeFactory(random);
        }


        private DegreeWithNaturalExponentFactory _degreeWithNaturalExponentFactory;
        private PropertiesOfDegreesFactory _propertiesOfDegreesFactory;
        private PropertiesOfDegreesWith0andNegativeFactory _propertiesOfDegreesWith0AndNegativeFactory;


        public GameSquareExample CalculateDegreeWithNaturalExponent()
        {
            Question question = _degreeWithNaturalExponentFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 15 };
        }

        public GameSquareExample CalculateDegreeProperties()
        {
            Question question = _propertiesOfDegreesFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

        public GameSquareExample CalculateDegreeWith0andNegativeExponentProperties()
        {
            Question question = _propertiesOfDegreesWith0AndNegativeFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }
    }
}
