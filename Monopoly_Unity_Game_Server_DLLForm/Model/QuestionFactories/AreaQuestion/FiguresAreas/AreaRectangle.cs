using Monopoly_Unity_Game_Server.Model.AreaQuestion;
using System;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.AreaQuestion.FiguresAreas
{
    public class AreaRectangle : IFigureAreaQuestion
    {
        public AreaRectangle(Random random)
        {
            _random = random;
        }


        private Random _random;

        private double _x1 = 0;
        private double _x2 = 0;


        public string QuestionText => "Найдите площадь прямоугольника, если длина стороны x1 = " + _x1 + ", а длина стороны x2 = " + _x2;

        public double FigureArea => _x1 * _x2;

        public void GenerateFigure()
        {
            _x1 = (double)_random.Next(1, 50) / 2;
            _x2 = (double)_random.Next(1, 50) / 2;
        }
    }
}
