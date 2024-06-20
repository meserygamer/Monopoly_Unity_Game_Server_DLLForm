using Monopoly_Unity_Game_Server.Model;
using System;

namespace Monopoly_Unity_Game_Server.ControlThemesQuestionsGenerators
{
    public class FigureAreaThemeQuestionsGenerator
    {
        public FigureAreaThemeQuestionsGenerator() 
        {
            Random random = new Random();
            _calculationArea_1 = new CalculationArea_1(random);
            _calculationArea_2 = new CalculationArea_2(random);
            _calculationArea_3 = new CalculationArea_3(random);
        }


        private CalculationArea_1 _calculationArea_1;
        private CalculationArea_2 _calculationArea_2;
        private CalculationArea_3 _calculationArea_3;


        public GameSquareExample GenerateArea_1Question()
        {
            Question question = _calculationArea_1.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

        public GameSquareExample GenerateArea_2Question()
        {
            Question question = _calculationArea_2.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 25 };
        }

        public GameSquareExample GenerateArea_3Question()
        {
            Question question = _calculationArea_3.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 30 };
        }
    }
}


