namespace SchellingModelOfSegregation;

public class ModelOfSegregation
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Title = "Schelling Model Of Segregation";
        Console.CursorVisible = false;

        ConsoleGUI consoleGUI = new ConsoleGUI();
        consoleGUI.Go();
    }
}
