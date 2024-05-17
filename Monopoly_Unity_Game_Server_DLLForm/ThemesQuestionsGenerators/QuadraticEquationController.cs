using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Route("QuadraticEquation/")]
    public class QuadraticEquationController : Controller
    {
        public QuadraticEquationController(QuadraticEquationWithA1QuestionFactory quadraticEquationWithA1QuestionFactory,
            QuadraticEquationWithB0_C0Factory quadraticEquationWithB0_C0Factory,
            QuadraticEquationWithANot0And1Factory quadraticEquationWithANot0And1Factory) 
        {
            _quadraticEquationWithA1QuestionFactory = quadraticEquationWithA1QuestionFactory;
            _quadraticEquationWithB0_C0Factory = quadraticEquationWithB0_C0Factory;
            _quadraticEquationWithANot0And1Factory = quadraticEquationWithANot0And1Factory;
        }


        private QuadraticEquationWithA1QuestionFactory _quadraticEquationWithA1QuestionFactory;
        private QuadraticEquationWithB0_C0Factory _quadraticEquationWithB0_C0Factory;
        private QuadraticEquationWithANot0And1Factory _quadraticEquationWithANot0And1Factory;


        [HttpGet]
        [Route("QuadraticEquationWithA1QuestionFactory")]
        public GameSquareExample GenerateQuadraticEquationWithA1Question()
        {
            Question question = _quadraticEquationWithA1QuestionFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

        [HttpGet]
        [Route("QuadraticEquationWithB0_orC0QuestionFactory")]
        public GameSquareExample QuadraticEquationWithB0_orC0Question()
        {
            Question question = _quadraticEquationWithB0_C0Factory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

        [HttpGet]
        [Route("QuadraticEquationWithANot0And1Factory")]
        public GameSquareExample QuadraticEquationWithANot0And1Question()
        {
            Question question = _quadraticEquationWithANot0And1Factory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }
    }
}


