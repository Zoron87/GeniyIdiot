namespace BallGamesWinFormsApp
{
    public class RandomSizeAndPointBall : RandomBall
    {
        public RandomSizeAndPointBall(MainForm form) : base(form)
        {
            vx = random.Next(-5, 5);
            vy = random.Next(-5, 5);
            size = random.Next(30, 100);
        }
    }

}
