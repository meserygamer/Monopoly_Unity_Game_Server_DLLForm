using Monopoly_Unity_Game_Server.Model.AreaQuestion;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.AreaQuestion.FiguresAreas
{
    public class AreaSquare : IFigureAreaQuestion
    {
        public AreaSquare(Random random)
        {
            _random = random;
        }


        private Random _random;

        private double _x1 = 0;


        public string QuestionText => "Найдите площадь квадрата, если длина стороны x1 = " + _x1;

        public double FigureArea => Math.Pow(_x1, 2);

        public void GenerateFigure()
        {
            _x1 = (double)_random.Next(1, 50) / 2;
        }
    }
}
