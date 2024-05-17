namespace Monopoly_Unity_Game_Server.Model.AreaQuestion
{
    public interface IFigureAreaQuestion
    {
        public string QuestionText { get; }

        public double FigureArea { get; }


        public void GenerateFigure();
    }
}
