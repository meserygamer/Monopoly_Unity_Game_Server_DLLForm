using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Route("OralCount/")]
    public class OralCountController : Controller
    {
        public OralCountController(SingleActionQuestionFactory singleActionQuestionFactory, DoubleActionQuestionFactory doubleActionQuestionFactory)
        {
            _singleActionQuestionFactory = singleActionQuestionFactory;
            _doubleActionQuestionFactory = doubleActionQuestionFactory;
        }


        private SingleActionQuestionFactory _singleActionQuestionFactory;
        private DoubleActionQuestionFactory _doubleActionQuestionFactory;


        [HttpGet]
        [Route("ExampleWithSingleAction")]
        public GameSquareExample GenerateExampleWithSingleAction()
        {
            Question question = _singleActionQuestionFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 10 };
        }

        [HttpGet]
        [Route("ExampleWithDoubleAction")]
        public GameSquareExample GenerateExampleWithDoubleAction()
        {
            Question question = _doubleActionQuestionFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 18 };
        }
    }
}
