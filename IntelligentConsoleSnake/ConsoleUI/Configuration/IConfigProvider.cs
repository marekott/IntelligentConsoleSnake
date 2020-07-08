namespace ConsoleUI.Configuration
{
    public interface IConfigProvider
    {
        int GetMapHeight();
        int GetMapWidth();
        int GetGameLeftOffset();
        int GetGameTopOffset();
    }
}