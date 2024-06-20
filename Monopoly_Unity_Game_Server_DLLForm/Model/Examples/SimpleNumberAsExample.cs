namespace Monopoly_Unity_Game_Server
{
    public class UserExample : Example
    {
        public UserExample(double answer, string exampleInString)
        {
            _answer = answer;
            _exampleInString = exampleInString;
        }


        private double _answer;

        private string _exampleInString;


        public override string GetExampleResult() => _answer.ToString();

        public override string ExampleInString() => _exampleInString;
    }
}



