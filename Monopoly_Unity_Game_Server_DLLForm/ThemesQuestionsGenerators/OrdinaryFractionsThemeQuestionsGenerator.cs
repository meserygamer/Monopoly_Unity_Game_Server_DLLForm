using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.OrdinaryFractions;
using System;

namespace Monopoly_Unity_Game_Server.ControlThemesQuestionsGenerators
{
    public class OrdinaryFractionsThemeQuestionsGenerator
    {
        public OrdinaryFractionsThemeQuestionsGenerator()
        {
            Random random = new Random();
            _ordinaryFractionsWithSameDenominatorsFactory = new OrdinaryFractionsWithSameDenominatorsFactory(random);
            _ordinaryFractionsWithDiffentDenominatorsFactory = new OrdinaryFractionsWithDifferentDenominatorsFactory(random);
            _ordinaryFractionsWithTwoActionsFactory = new OrdinaryFractionsWithTwoActionsFactory(random);
        }


        private OrdinaryFractionsWithSameDenominatorsFactory _ordinaryFractionsWithSameDenominatorsFactory;
        private OrdinaryFractionsWithDifferentDenominatorsFactory _ordinaryFractionsWithDiffentDenominatorsFactory;
        private OrdinaryFractionsWithTwoActionsFactory _ordinaryFractionsWithTwoActionsFactory;


        public GameSquareExample CalculateOrdinaryFractionsWithSameDenominators() 
        {
            Question question = _ordinaryFractionsWithSameDenominatorsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

        public GameSquareExample CalculateOrdinaryFractionsWithDifferentDenominators()
        {
            Question question = _ordinaryFractionsWithDiffentDenominatorsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 25 };
        }

        public GameSquareExample CalculateOrdinaryFractionsWithTwoActions()
        {
            Question question = _ordinaryFractionsWithTwoActionsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 35 };
        }

    }
}
