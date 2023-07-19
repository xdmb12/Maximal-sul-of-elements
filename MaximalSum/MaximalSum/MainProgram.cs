namespace MaximalSum;

public class MainProgram
{
    public static void Main(string[] args)
    {
        var log = new UserOutput();
        // var param = "E:\\1.txt";
        Console.Write("Enter your path of file(txt): ");
        var path = Console.ReadLine();
        try
        {
            log.MaximalSumOfElements(path);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}