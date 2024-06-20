using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories;
using System;

namespace Monopoly_Unity_Game_Server.ControlThemesQuestionsGenerators
{
    public class QuadraticEquationThemeQuestionsGenerator
    {
        public QuadraticEquationThemeQuestionsGenerator() 
        {
            Random random = new Random();
            _quadraticEquationWithA1QuestionFactory = new QuadraticEquationWithA1QuestionFactory(random);
            _quadraticEquationWithB0_C0Factory = new QuadraticEquationWithB0_C0Factory(random);
            _quadraticEquationWithANot0And1Factory = new QuadraticEquationWithANot0And1Factory(random);
        }


        private QuadraticEquationWithA1QuestionFactory _quadraticEquationWithA1QuestionFactory;
        private QuadraticEquationWithB0_C0Factory _quadraticEquationWithB0_C0Factory;
        private QuadraticEquationWithANot0And1Factory _quadraticEquationWithANot0And1Factory;


        public GameSquareExample GenerateQuadraticEquationWithA1Question()
        {
            Question question = _quadraticEquationWithA1QuestionFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 30 };
        }

        public GameSquareExample QuadraticEquationWithB0_orC0Question()
        {
            Question question = _quadraticEquationWithB0_C0Factory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 30 };
        }

        public GameSquareExample QuadraticEquationWithANot0And1Question()
        {
            Question question = _quadraticEquationWithANot0And1Factory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 30 };
        }
    }
}