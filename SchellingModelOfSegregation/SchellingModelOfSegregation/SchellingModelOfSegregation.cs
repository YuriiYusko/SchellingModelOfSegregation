namespace SchellingModelOfSegregation;

public class ModelOfSegregation
{
    public static void Main(string[] args)
    {
        double percebt = 12;
        double i = 1;
        double j = 7;

        bool happy = percebt <= (i / (i + j) * 100);
        Console.WriteLine(happy);

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Title = "Schelling Model Of Segregation";
        Console.CursorVisible = false;

        ConsoleGUI consoleGUI = new ConsoleGUI();
        consoleGUI.Go();
    }
}
