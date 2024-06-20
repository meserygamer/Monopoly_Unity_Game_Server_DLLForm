using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.DegreeQuestion
{
    public class PropertiesOfDegreesWith0andNegativeFactory : IQuestionFactory
    {
        public PropertiesOfDegreesWith0andNegativeFactory(Random random)
        {
            _random = random;

            _possibleProperties = new List<Func<Example>>()
            {
                GenerateExampleOn0ExponentPropertieOfDegrees,
                GenerateExampleOnNegativeExponentPropertieOfDegrees,
            };
        }


        private Random _random;

        private readonly List<Func<Example>> _possibleProperties;

        private readonly Dictionary<int, List<int>> _degreeBaseAndPossibleExponent = new Dictionary<int, List<int>>() 
        {
            { 1, new List<int>() { -1, -2, -3, -4, -5, -6, -7, -8, -9, } },
            { 2, new List<int>() { -1, -2, -3} },
            { 4, new List<int>() { -1}},
            { 5, new List<int>() { -1, -2, -3}},
            { 8, new List<int>() { -1}},
            { 10, new List<int>() {-1, -2, -3}},
            { 25, new List<int>() {-1}},
            { 50, new List<int>() {-1}},
            { 100, new List<int>() {-1}},
            { -1, new List<int>() { -1, -2, -3, -4, -5, -6, -7, -8, -9, } },
            { -2, new List<int>() { -1, -2, -3} },
            { -4, new List<int>() { -1}},
            { -5, new List<int>() { -1, -2, -3}},
            { -8, new List<int>() { -1}},
            { -10, new List<int>() {-1, -2, -3}},
            { -25, new List<int>() {-1}},
            { -50, new List<int>() {-1}},
            { -100, new List<int>() {-1}}
        };


        public Question GetQuestion()
        {
            Question question = new Question();

            Example example = _possibleProperties[(_random.Next(0, 4) == 0)? 0 : 1].Invoke();

            question.QuestionText = example.ExampleInString();
            question.Answers = new string[] { example.GetExampleResult() };

            return question;
        }


        private Example GenerateExampleOn0ExponentPropertieOfDegrees()
            => new ExampleWithTwoArguments(new SimpleNumberAsExample(_random.Next(-100, 101)), new SimpleNumberAsExample(0), ActionType.Exponentiation);

        private Example GenerateExampleOnNegativeExponentPropertieOfDegrees()
        {
            Dictionary<int, List<int>>.KeyCollection possibleBase = _degreeBaseAndPossibleExponent.Keys;
            int degreeBase = possibleBase.ElementAt(_random.Next(0, possibleBase.Count));
            List<int> possibleExponents = _degreeBaseAndPossibleExponent[degreeBase];
            int degreeExponent = possibleExponents[_random.Next(0, possibleExponents.Count)];

            return new ExampleWithTwoArguments(new SimpleNumberAsExample(degreeBase), new SimpleNumberAsExample(degreeExponent), ActionType.Exponentiation);
        }
    }
}
