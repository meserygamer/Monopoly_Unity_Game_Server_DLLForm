namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.FigureCharacteristics
{
    public class TriangleSquareRectangleCharacteristicsFactory : IQuestionFactory
    {
        public TriangleSquareRectangleCharacteristicsFactory(Random random)
        {
            _random = random;
            _questions = new List<Func<Question>>()
            {
                GetTriangleHeighQuestion,
                GetTriangleBaseQuestion,
                GetSquareSideQuestion,
                GetSquareDiagonalQuestion,
                GetRectangleSideQuestion,
                GetRectangleDiagonalQuestion
            };
        }


        private Random _random;

        private List<Func<Question>> _questions;


        public Question GetQuestion() => _questions[_random.Next(0, _questions.Count)].Invoke();

        private List<int> FindAllDividers(int number)
        {
            List<int> dividers = new List<int>();
            for (int i = 1; i * i < number; i++)
                if (number % i == 0) dividers.AddRange([i, number / i]);
            return dividers;
        }

        private List<double> FindAllDividers(double number, double[] acceptableBalance)
        {
            List<double> dividers = new List<double>();
            for (int i = 1; i * i < number; i++)
                if (number % i == 0 || acceptableBalance.Contains((number / i) % 1d)) dividers.AddRange([i, number / i]);
            return dividers;
        }

        private List<int> FindAllNumbersSquares(int maxNumber)
        {
            List<int> allSquares = new List<int>();
            for(int i = 1; i < maxNumber; i++)
            {
                allSquares.Add(i*i);
            }
            return allSquares;
        }

        private Question GetTriangleHeighQuestion()
        {
            int triangleArea;
            List<int> possibleBases;
            do
            {
                triangleArea = _random.Next(1, 100);
                possibleBases = FindAllDividers(triangleArea * 2);
            }
            while (possibleBases.Count <= 2);
            int triangleBase = possibleBases[_random.Next(0, possibleBases.Count)];
            Question triangleQuestion = new Question();
            triangleQuestion.QuestionText = $"Найдите высоту треугольника, если площадь = {triangleArea} , а основание =  {triangleBase}";
            triangleQuestion.Answers = [((double)triangleArea * 2d / (double)triangleBase).ToString()];
            return triangleQuestion;
        }

        private Question GetTriangleBaseQuestion()
        {
            int triangleArea = _random.Next(1, 100);
            List<int> possibleHeights = FindAllDividers(triangleArea * 2);
            int triangleHeight = possibleHeights[_random.Next(0, possibleHeights.Count)];
            Question triangleQuestion = new Question();
            triangleQuestion.QuestionText = $"Найдите основание треугольника, если площадь = {triangleArea} , а высота =  {triangleHeight}";
            triangleQuestion.Answers = [((double)triangleArea * 2d / (double)triangleHeight).ToString()];
            return triangleQuestion;
        }

        private Question GetSquareSideQuestion()
        {
            double squareSide = (double)_random.Next(1, 20);
            double squareArea = Math.Pow(squareSide, 2);
            Question triangleQuestion = new Question();
            triangleQuestion.QuestionText = $"Найдите сторону квадрата, если площадь = {squareArea}";
            triangleQuestion.Answers = [squareSide.ToString()];
            return triangleQuestion;
        }

        private Question GetSquareDiagonalQuestion()
        {
            double squareDiagonal = (double)_random.Next(1, 20);
            double squareArea = Math.Pow(squareDiagonal, 2) / 2;
            Question triangleQuestion = new Question();
            triangleQuestion.QuestionText = $"Найдите диагональ квадрата, если площадь = {squareArea}";
            triangleQuestion.Answers = [squareDiagonal.ToString()];
            return triangleQuestion;
        }

        private Question GetRectangleSideQuestion() 
        {
            double rectangleArea = _random.Next(1, 100);
            List<double> possibleASideLenght = FindAllDividers(rectangleArea, [0.25, 0.5, 0.75]);
            double rectangleASideLenght = possibleASideLenght[_random.Next(0, possibleASideLenght.Count)];
            Question triangleQuestion = new Question();
            triangleQuestion.QuestionText = $"Найдите сторону b прямоугольника, если площадь = {rectangleArea}, а сторона a = {rectangleASideLenght}";
            triangleQuestion.Answers = [(rectangleArea / rectangleASideLenght).ToString()];
            return triangleQuestion;
        }

        private Question GetRectangleDiagonalQuestion()
        {
            List<int> squares = FindAllNumbersSquares(30);
            List<int> possibleBSide;
            int rectangleASide;

            do
            {
                rectangleASide = squares[_random.Next(0, squares.Count)];
                possibleBSide = new List<int>();
                foreach(var possibleSide in squares)
                    if(squares.Contains(possibleSide + rectangleASide))
                        possibleBSide.Add(possibleSide);

            }
            while (possibleBSide.Count == 0);

            int rectangleBSide = possibleBSide[_random.Next(0, possibleBSide.Count)];

            Question triangleQuestion = new Question();
            triangleQuestion.QuestionText = $"Найдите диагональ прямоугольника, если сторона a = {Math.Pow(rectangleASide, 1d / 2d)}, а сторона b = {Math.Pow(rectangleBSide, 1d / 2d)}";
            triangleQuestion.Answers = [(rectangleASide + rectangleBSide).ToString()];
            return triangleQuestion;

        }

        
    }
}
