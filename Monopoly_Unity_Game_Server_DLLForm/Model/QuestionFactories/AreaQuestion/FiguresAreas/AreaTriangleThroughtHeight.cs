using Monopoly_Unity_Game_Server.Model.AreaQuestion;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.AreaQuestion.FiguresAreas
{
    public class AreaTriangleThroughtHeight : IFigureAreaQuestion
    {
        public AreaTriangleThroughtHeight(Random random)
        {
            _random = random;
        }


        private Random _random;

        private double _a = 0;
        private double _h = 0;


        public string QuestionText => "Найдите площадь треугольника, если высота = " + _h + ", а основание = " + _a;

        public double FigureArea => 0.5 * _a * _h;

        public void GenerateFigure()
        {
            _a = (double)_random.Next(1, 50) / 2;
            _h = (double)_random.Next(1, 50) / 2;
        }
    }
}
