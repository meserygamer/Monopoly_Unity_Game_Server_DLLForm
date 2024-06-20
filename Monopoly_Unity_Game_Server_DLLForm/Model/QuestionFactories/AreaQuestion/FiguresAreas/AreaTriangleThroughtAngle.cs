using Monopoly_Unity_Game_Server.Model.AreaQuestion;
using System;
using System.Collections.Generic;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.AreaQuestion.FiguresAreas
{
    public class AreaTriangleThroughtAngle : IFigureAreaQuestion
    {
        public AreaTriangleThroughtAngle(Random random)
        {
            _random = random;
        }

        private readonly int[] POSSIBLE_ANGLES = new int[] { 30, 60, 45 };
        private readonly Dictionary<int, string> angleSquare = new Dictionary<int, string>() { {30, ""}, { 45, "√2" }, { 60, "√3" } };


        private Random _random;

        private double _a = 0;
        private double _b = 0;
        private double _alphaAngle = 0;
        private double _multiplicator;


        public string QuestionText => 
            $"Найдите площадь треугольника, если сторона a = {_a}, сторона b = {_b}{angleSquare[(int)_alphaAngle]}, а угол между ними alpha = " + _alphaAngle + "°";

        public double FigureArea => 0.5 * _a * _b * _multiplicator;


        public void GenerateFigure()
        {
            _a = (double)_random.Next(1, 26);
            _b = (double)_random.Next(1, 26);
            _alphaAngle = POSSIBLE_ANGLES[_random.Next(0, POSSIBLE_ANGLES.Length)];
            _multiplicator = (_alphaAngle == 30)? 0.5 : (_alphaAngle == 45)? 1 : 1.5;
        }
    }
}
