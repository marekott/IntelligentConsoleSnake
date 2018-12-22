
namespace IntelligentConsoleSnake
{
	public class Score
	{
		private const int LeftScorePosition = 5;
		private const int TopScorePosition = 3;
		private int _point;

		public Score()
		{
			_point = 0;
		}

		public void ManipulateScore(PointToCollect reward)
		{
			_point += reward.PointWithValue;
			ShowScore();
		}

		private void ShowScore()
		{
			string scoreText = "Score: " + _point;

			BoardDrawer.WriteOnBoard(LeftScorePosition, TopScorePosition, scoreText);
		}
	}
}
