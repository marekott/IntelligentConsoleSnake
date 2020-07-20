namespace SnakeGame.Interfaces
{
    public interface ISnakeBot
    {
        DirectionOfMove ChooseDirection(Snake snake, Reward reward, Map map);
    }
}
