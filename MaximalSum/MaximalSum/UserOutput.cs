using MaximalSum.Resources;

namespace MaximalSum;

public class UserOutput
{
    public void MaximalSumOfElements(string path)
    {
        var lg = new Logic();
        ListOutput(lg.GetSumsInArray(lg.FileRider(path)));
    }

    private void ListOutput(string[] arrayOfNumbers)
    {
        var lg = new Logic();
        var sumList = new List<string>();
        var brokenLinesList = new List<int>();
        var i = 1;
        var largestNumber = lg.GetLargestElementUsingFor(lg.ConvertStringToDecimal(arrayOfNumbers));

        try
        {
            foreach (var line in arrayOfNumbers)
            {
                if (!line.Contains(MaxSumConstants.brokenLine))
                {
                    Console.WriteLine(MaximalSumResources.UserOutput_Line_Sum, i, line);
                    sumList.Add(line);
                }
                else
                {
                    brokenLinesList.Add(i);
                }

                i++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.Write(MaximalSumResources.BrokenLinesResource);
        PrintListOfLines(brokenLinesList.ToArray());
        Console.WriteLine();
        Console.Write(MaximalSumResources.LineMaxSumResource);
        PrintListOfLines(lg.GetArrayOfMaxSumLines(arrayOfNumbers, largestNumber));
    }

    private void PrintListOfLines(int[] brokenList)
    {
        foreach (var i in brokenList)
        {
            Console.Write($"{i} ");
        }
    }
}