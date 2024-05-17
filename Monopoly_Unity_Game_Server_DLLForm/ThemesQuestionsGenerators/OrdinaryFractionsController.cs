using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.OrdinaryFractions;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.RootQuestion;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Controller]
    [Route("OrdinaryFractions/")]
    public class OrdinaryFractionsController : Controller
    {
        public OrdinaryFractionsController( OrdinaryFractionsWithSameDenominatorsFactory ordinaryFractionsWithSameDenominatorsFactory,
                                            OrdinaryFractionsWithDifferentDenominatorsFactory ordinaryFractionsWithDiffentDenominatorsFactory,
                                            OrdinaryFractionsWithTwoActionsFactory ordinaryFractionsWithTwoActionsFactory   )
        {
            _ordinaryFractionsWithSameDenominatorsFactory = ordinaryFractionsWithSameDenominatorsFactory;
            _ordinaryFractionsWithDiffentDenominatorsFactory = ordinaryFractionsWithDiffentDenominatorsFactory;
            _ordinaryFractionsWithTwoActionsFactory = ordinaryFractionsWithTwoActionsFactory;
        }


        private OrdinaryFractionsWithSameDenominatorsFactory _ordinaryFractionsWithSameDenominatorsFactory;
        private OrdinaryFractionsWithDifferentDenominatorsFactory _ordinaryFractionsWithDiffentDenominatorsFactory;
        private OrdinaryFractionsWithTwoActionsFactory _ordinaryFractionsWithTwoActionsFactory;


        [HttpGet]
        [Route("CalculateOrdinaryFractionsWithSameDenominators")]
        public GameSquareExample CalculateOrdinaryFractionsWithSameDenominators() 
        {
            Question question = _ordinaryFractionsWithSameDenominatorsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

        [HttpGet]
        [Route("CalculateOrdinaryFractionsWithDifferentDenominators")]
        public GameSquareExample CalculateOrdinaryFractionsWithDifferentDenominators()
        {
            Question question = _ordinaryFractionsWithDiffentDenominatorsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

        [HttpGet]
        [Route("CalculateOrdinaryFractionsWithTwoActions")]
        public GameSquareExample CalculateOrdinaryFractionsWithTwoActions()
        {
            Question question = _ordinaryFractionsWithTwoActionsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

    }
}
