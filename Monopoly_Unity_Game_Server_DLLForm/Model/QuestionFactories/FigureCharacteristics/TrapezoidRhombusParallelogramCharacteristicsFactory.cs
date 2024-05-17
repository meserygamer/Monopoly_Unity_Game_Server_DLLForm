namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.FigureCharacteristics
{
    public class TrapezoidRhombusParallelogramCharacteristicsFactory : IQuestionFactory
    {
        public TrapezoidRhombusParallelogramCharacteristicsFactory(Random random)
        {
            _random = random;
            _questions = new List<Func<Question>>()
            {
                GetTrapezoidHeighQuestion,
                GetTrapezoidMiddleLineQuestion,
                GetRhombusDiagonalQuestion,
                GetRhombusBaseQuestion,
                GetParallelogramHeightQuestion,
                GetParallelogramBaseQuestion
            };
        }


        private Random _random;

        private List<Func<Question>> _questions;

        private Dictionary<int, string> _degreesAndSin = new Dictionary<int, string>() { { 30, "" }, { 45, "√2" }, { 60, "√3" } };


        public Question GetQuestion() => _questions[_random.Next(0, _questions.Count)].Invoke();

        private List<int> FindAllDividers(int number)
        {
            List<int> dividers = new List<int>();
            for (int i = 1; i * i <= number; i++)
                if (number % i == 0) dividers.AddRange([i, number / i]);
            return dividers;
        }

        private Question GetTrapezoidHeighQuestion()
        {
            int trapezoidArea = _random.Next(2, 50);
            List<int> possibleBaseSum = FindAllDividers(trapezoidArea * 2);
            int baseSum = possibleBaseSum[_random.Next(2, possibleBaseSum.Count)];
            int aBase = _random.Next(1, baseSum);
            int bBase = baseSum - aBase;
            Question trapezoidQuestion = new Question();
            trapezoidQuestion.QuestionText = $"Найдите высоту трапеции, если площадь = {trapezoidArea} , основание a = {aBase}, а основание b = {bBase}";
            trapezoidQuestion.Answers = [((double)trapezoidArea * 2 / (aBase + bBase)).ToString()];
            return trapezoidQuestion;
        }

        private Question GetTrapezoidMiddleLineQuestion()
        {
            int trapezoidArea = _random.Next(2, 50);
            List<int> possibleHeight = FindAllDividers(trapezoidArea);
            int height = possibleHeight[_random.Next(0, possibleHeight.Count)];
            Question trapezoidQuestion = new Question();
            trapezoidQuestion.QuestionText = $"Найдите среднюю линию трапеции, если площадь = {trapezoidArea} , а высота = {height}";
            trapezoidQuestion.Answers = [((double)trapezoidArea / height).ToString()];
            return trapezoidQuestion;
        }

        private Question GetRhombusDiagonalQuestion()
        {
            int rhombusADiagonal = _random.Next(1, 30);
            int rhombusBDiagonal = _random.Next(1, 30);
            double rhombusArea = (double)rhombusADiagonal * (double)rhombusBDiagonal / 2d;

            Question rhombusQuestion = new Question();
            rhombusQuestion.QuestionText = $"Найдите диагональ a ромба , если площадь = {rhombusArea} , а диагональ b = {rhombusBDiagonal}";
            rhombusQuestion.Answers = [(rhombusADiagonal).ToString()];
            return rhombusQuestion;
        }

        private Question GetRhombusBaseQuestion()
        {
            int rhombusArea = _random.Next(2, 50);
            List<int> possibleHeight = FindAllDividers(rhombusArea);
            int height = possibleHeight[_random.Next(0, possibleHeight.Count)];
            Question rhombusQuestion = new Question();
            rhombusQuestion.QuestionText = $"Найдите сторону ромба, если площадь = {rhombusArea} , а высота = {height}";
            rhombusQuestion.Answers = [((double)rhombusArea / height).ToString()];
            return rhombusQuestion;
        }

        private Question GetParallelogramHeightQuestion() 
        {
            int parallelogramArea = _random.Next(2, 50);
            List<int> possibleBase = FindAllDividers(parallelogramArea);
            int parallelogramBase = possibleBase[_random.Next(0, possibleBase.Count)];
            Question rhombusQuestion = new Question();
            rhombusQuestion.QuestionText = $"Найдите высоту параллелограмма, если площадь = {parallelogramArea}, а сторона к которой проведена высота = {parallelogramBase}";
            rhombusQuestion.Answers = [((double)parallelogramArea / parallelogramBase).ToString()];
            return rhombusQuestion;
        }

        private Question GetParallelogramBaseQuestion()
        {
            int degree = 30 + 15 * _random.Next(0, 3);
            double multiplicator = (degree == 30) ? 0.5 : (degree == 45) ? 1 : 1.5;
            int parallelogramArea;
            if (multiplicator == 1.5)
            {
                List<int> ints = new List<int>();
                for(int i = 1; i < 50; i++ )
                {
                    if((double)i % 1.5 == 0) ints.Add(i);
                }
                parallelogramArea = ints[_random.Next(0, ints.Count)];
            }
            else
            {
                parallelogramArea = _random.Next(2, 50);
            }
            
            List<int> possibleBase = FindAllDividers((int)(parallelogramArea / multiplicator));
            int baseB = possibleBase[_random.Next(0, possibleBase.Count)];

            Question triangleQuestion = new Question();
            triangleQuestion.QuestionText = $"Найдите сторону а параллелограмма, если сторона b = {baseB}{_degreesAndSin[degree]}, угол между сторонами a и b = {degree}, а площадь = {parallelogramArea}";
            triangleQuestion.Answers = [(parallelogramArea / multiplicator / baseB).ToString()];
            return triangleQuestion;

        }

        
    }
}
