namespace ConsoleUI
{
    public interface IConfigProvider
    {
        int GetMapHeight();
        int GetMapWidth();
        int GetGameLeftOffset();
        int GetGameTopOffset();
    }
}