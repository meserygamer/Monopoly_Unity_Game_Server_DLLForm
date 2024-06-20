using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.FigureCharacteristics;
using System;

namespace Monopoly_Unity_Game_Server.ControlThemesQuestionsGenerators
{
    public class FigureCharacteristicsThemeQuestionsGenerator
    {
        public FigureCharacteristicsThemeQuestionsGenerator()
        {
            Random random = new Random();
            _triangleSquareRectangleCharacteristicsFactory = new TriangleSquareRectangleCharacteristicsFactory(random);
            _trapezoidRhombusParallelogramCharacteristicsFactory = new TrapezoidRhombusParallelogramCharacteristicsFactory(random);
        }


        private TriangleSquareRectangleCharacteristicsFactory _triangleSquareRectangleCharacteristicsFactory;
        private TrapezoidRhombusParallelogramCharacteristicsFactory _trapezoidRhombusParallelogramCharacteristicsFactory;


        public GameSquareExample CalculateTriangleSquareRectangleCharacteristics() 
        {
            Question question = _triangleSquareRectangleCharacteristicsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 25 };
        }

        public GameSquareExample CalculateTrapezoidRhombusParallelogramCharacteristics()
        {
            Question question = _trapezoidRhombusParallelogramCharacteristicsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 30 };
        }

    }
}
