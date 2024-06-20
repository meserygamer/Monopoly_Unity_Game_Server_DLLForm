using Monopoly_Unity_Game_Server.Model.AreaQuestion;
using System;
using System.Collections.Generic;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.AreaQuestion.FiguresAreas
{
    public class AreaDiamondThroughtAngle : IFigureAreaQuestion
    {
        public AreaDiamondThroughtAngle(Random random)
        {
            _random = random;
        }

        private readonly int[] POSSIBLE_ANGLES = new int[] { 30, 60, 45 };
        private readonly Dictionary<int, string> angleSquare = new Dictionary<int, string>() { { 30, "" }, { 45, " * 2^(1/4)" }, { 60, " * 3^(1/4)" } };


        private Random _random;

        private double _a1 = 0;
        private double _alphaAngle = 0;
        private double _multiplicator;


        public string QuestionText =>
            $"Найдите площадь ромба, если сторона a1 = {_a1}{angleSquare[(int)_alphaAngle]}, сторона a2 = {_a1}{angleSquare[(int)_alphaAngle]}, а угол между ними alpha = " + _alphaAngle + "°";

        public double FigureArea => Math.Pow(_a1, 2) * _multiplicator;


        public void GenerateFigure()
        {
            _a1 = (double)_random.Next(1, 50) / 2;
            _alphaAngle = POSSIBLE_ANGLES[_random.Next(0, POSSIBLE_ANGLES.Length)];
            _multiplicator = (_alphaAngle == 30) ? 0.5 : (_alphaAngle == 45) ? 1 : 1.5;
        }
    }
}
