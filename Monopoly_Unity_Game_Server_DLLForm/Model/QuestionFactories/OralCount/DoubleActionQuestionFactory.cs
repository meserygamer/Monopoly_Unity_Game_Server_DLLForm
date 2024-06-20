using Monopoly_Unity_Game_Server.Model;
using System.Collections.Generic;
using System;

namespace Monopoly_Unity_Game_Server
{
    /// <summary>
    /// Генератор примеров вида x (+|-|*|/) y
    /// </summary>
    public class DoubleActionQuestionFactory : IQuestionFactory
    {
        public DoubleActionQuestionFactory(Random random)
        {
            _random = random;
        }


        private Random _random;


        public Question GetQuestion()
        {
            Example example = GetExample();
            return new Question() { QuestionText = example.ExampleInString(), Answers = new string[] { example.GetExampleResult() } };
        }

        public Example GetExample()
        {
            ActionType exampleActionType = (ActionType)_random.Next(0, 2);
            Example firstNumber = new SingleActionQuestionFactory(_random).GetExample();

            SimpleNumberAsExample secondNumber = new SimpleNumberAsExample(_random.Next(10, 501));
            return new ExampleWithTwoArguments(firstNumber, secondNumber, exampleActionType);
        }

        private List<int> FindAllDivisioners(int number)
        {
            List<int> Divioners = new List<int>();
            for (int i = 1; i * i <= Math.Abs(number); i++)
                if (number % i == 0) Divioners.AddRange(new int[] { i, number / i });
            return Divioners;
        }
    }
}



