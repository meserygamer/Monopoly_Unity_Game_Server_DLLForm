using Monopoly_Unity_Game_Server.Model;
using System.Collections.Generic;
using System;

namespace Monopoly_Unity_Game_Server
{
    /// <summary>
    /// Генератор примеров вида x (+|-|*|/) y
    /// </summary>
    public class SingleActionQuestionFactory : IQuestionFactory
    {
        public SingleActionQuestionFactory(Random random)
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
            ActionType exampleActionType = (ActionType)_random.Next(0, 4);
            int firstNumberInNumberForm = _random.Next(10, 501);
            SimpleNumberAsExample firstNumber = new SimpleNumberAsExample(firstNumberInNumberForm);

            SimpleNumberAsExample secondNumber;
            if (exampleActionType == ActionType.Addition || exampleActionType == ActionType.Subtraction)                        //Если числа складываются или вычитаются, то второе число 2 или 3 значное, иначе 1 значное
            {
                secondNumber = new SimpleNumberAsExample(_random.Next(10, 501));
            }
            else
            {
                if (exampleActionType == ActionType.Division)
                {
                    List<int> possibleSecondNumber = FindAllDivisioners(firstNumberInNumberForm);
                    secondNumber = new SimpleNumberAsExample(possibleSecondNumber[_random.Next(0, possibleSecondNumber.Count)]);
                }
                else
                {
                    secondNumber = new SimpleNumberAsExample(_random.Next(1, 6));
                }
            }
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



