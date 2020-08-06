namespace SnakeGame.Interfaces
{
    public interface ISnakeBot
    {
        DirectionOfMove ChooseDirection(IntelligentSnake snake, Reward reward, Map map);
    }
}
