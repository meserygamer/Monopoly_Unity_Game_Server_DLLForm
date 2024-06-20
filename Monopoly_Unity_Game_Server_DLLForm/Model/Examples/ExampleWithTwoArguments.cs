using System;
using System.Text;

namespace Monopoly_Unity_Game_Server.Model
{
    public class ExampleWithTwoArguments : Example
    {
        public ExampleWithTwoArguments(Example FirstArg, Example SecondArg, ActionType actionType)
        {
            _firstArg = FirstArg;
            _secondArg = SecondArg;
            _actionType = actionType;
        }


        private Example _firstArg;
        private Example _secondArg;
        private ActionType _actionType;


        public Example FirstArg { get => _firstArg; set => _firstArg = value; }
        public Example SecondArg { get => _secondArg; set => _secondArg = value; }


        public override string GetExampleResult()
        {
            switch (_actionType)
            {
                case ActionType.Addition: return Math.Round(Convert.ToDouble(_firstArg.GetExampleResult()) + Convert.ToDouble(_secondArg.GetExampleResult()), 3).ToString();
                case ActionType.Subtraction: return Math.Round(Convert.ToDouble(_firstArg.GetExampleResult()) - Convert.ToDouble(_secondArg.GetExampleResult()), 3).ToString();
                case ActionType.Multiplication: return Math.Round(Convert.ToDouble(_firstArg.GetExampleResult()) * Convert.ToDouble(_secondArg.GetExampleResult()), 3).ToString();
                case ActionType.Division: return Math.Round(Convert.ToDouble(_firstArg.GetExampleResult()) / Convert.ToDouble(_secondArg.GetExampleResult()), 3).ToString();
                case ActionType.Exponentiation: return Math.Round(Math.Pow(Convert.ToDouble(_firstArg.GetExampleResult()), Convert.ToDouble(_secondArg.GetExampleResult())), 3).ToString();
                case ActionType.TakingRoot:
                    {
                        double firstArg = Convert.ToDouble(_firstArg.GetExampleResult());
                        double secondArg = Convert.ToDouble(_secondArg.GetExampleResult());
                        if ((double)(int)firstArg == firstArg && ((int)firstArg % 2) == 1 && secondArg < 0)
                            return Math.Round(-Math.Pow(-Convert.ToDouble(_secondArg.GetExampleResult()), 1d / Convert.ToDouble(_firstArg.GetExampleResult())), 3).ToString();
                        return Math.Round(Math.Pow(Convert.ToDouble(_secondArg.GetExampleResult()), 1d / Convert.ToDouble(_firstArg.GetExampleResult())), 3).ToString();
                    }
                default: return "NAN";
            }
        }

        public override string ExampleInString()
        {
            StringBuilder exampleInString = new StringBuilder();

            if (_firstArg is SimpleNumberAsExample)
                exampleInString.Append(_firstArg.ExampleInString());
            else
                exampleInString.Append("(" + _firstArg.ExampleInString() + ")");

            switch (_actionType)
            {
                case ActionType.Addition: exampleInString.Append(" + "); break;
                case ActionType.Subtraction: exampleInString.Append(" - "); break;
                case ActionType.Multiplication: exampleInString.Append(" * "); break;
                case ActionType.Division: exampleInString.Append(" / "); break;
                case ActionType.Exponentiation: exampleInString.Append(" ^ "); break;
                case ActionType.TakingRoot: exampleInString.Append(" √ "); break;
            }

            if (_secondArg is SimpleNumberAsExample)
                exampleInString.Append(_secondArg.ExampleInString());
            else
                exampleInString.Append("(" + _secondArg.ExampleInString() + ")");
            return exampleInString.ToString();
        }
    }
}


