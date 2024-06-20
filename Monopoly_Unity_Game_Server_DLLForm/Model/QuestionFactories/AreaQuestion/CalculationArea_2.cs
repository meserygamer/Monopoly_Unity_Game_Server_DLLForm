﻿using Monopoly_Unity_Game_Server.Model.AreaQuestion;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.AreaQuestion.FiguresAreas;
using System;
using System.Collections.Generic;

namespace Monopoly_Unity_Game_Server.Model
{
    public class CalculationArea_2 : IQuestionFactory
    {
        public CalculationArea_2(Random random)
        {
            _random = random;
            _PossibleFigures = new List<IFigureAreaQuestion>
            {
                new AreaTriangleThroughtAngle(_random),
                new AreaDiamondThroughtAngle(_random),
                new AreaSquare(_random)
            };
        }


        private Random _random;

        private readonly List<IFigureAreaQuestion> _PossibleFigures;


        public Question GetQuestion()
        {
            Question question = new Question();

            IFigureAreaQuestion figureArea = _PossibleFigures[_random.Next(0, _PossibleFigures.Count)];
            figureArea.GenerateFigure();
            question.QuestionText = figureArea.QuestionText;
            question.Answers = new string[] { figureArea.FigureArea.ToString() };

            return question;
        }
    }
}
