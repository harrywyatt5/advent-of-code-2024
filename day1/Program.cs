using day1;

public class Program
{
    public static void Main(string[] args)
    {
        using (var christmasReader = new ChristmasFileReader("input.txt"))
        {
            var listPair = christmasReader.GetListPair();
            var distance = listPair.CalculateDistance();
            Console.WriteLine(distance);
        }
    }
}