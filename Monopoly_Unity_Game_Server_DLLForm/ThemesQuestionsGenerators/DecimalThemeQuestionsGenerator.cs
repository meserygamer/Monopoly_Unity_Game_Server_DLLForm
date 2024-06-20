using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.DecimalExamples;
using System;

namespace Monopoly_Unity_Game_Server.ThemesQuestionsGenerators
{
    public class DecimalThemeQuestionsGenerator
    {
        public DecimalThemeQuestionsGenerator()
        {
            Random random = new Random();
            _decimalSimpleExampleOfAddOrSubFactory = new DecimalSimpleExampleOfAddOrSubFactory(random);
            _decimalSimpleExampleOfMulOrDivFactory = new DecimalSimpleExampleOfMulOrDivFactory(random);
            _decimalSimpleExampleWithTwoActionsFactory = new DecimalSimpleExampleWithTwoActionsFactory(random);
        }


        private DecimalSimpleExampleOfAddOrSubFactory _decimalSimpleExampleOfAddOrSubFactory;
        private DecimalSimpleExampleOfMulOrDivFactory _decimalSimpleExampleOfMulOrDivFactory;
        private DecimalSimpleExampleWithTwoActionsFactory _decimalSimpleExampleWithTwoActionsFactory;


        public GameSquareExample CalculateDecimalSimpleExampleOfAddOrSub() 
        {
            Question question = _decimalSimpleExampleOfAddOrSubFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

        public GameSquareExample CalculateDecimalSimpleExampleOfMulOrDiv()
        {
            Question question = _decimalSimpleExampleOfMulOrDivFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

        public GameSquareExample DecimalSimpleExampleWithTwoActions()
        {
            Question question = _decimalSimpleExampleWithTwoActionsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 35 };
        }

    }
}
