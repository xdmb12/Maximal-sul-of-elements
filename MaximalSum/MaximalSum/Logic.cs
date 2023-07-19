using System.Globalization;

namespace MaximalSum;

public class Logic
{
    public string[] FileRider(string filePath)
    {
        var fileLines = new List<string>();
        string[] result;

        try
        {
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    fileLines.Add(line);
                }
            }
        }
        catch (Exception ex)
        {
            switch (ex)
            {
                case NullReferenceException:
                    throw new NullReferenceException("Null Reference Exception");
                case FileNotFoundException:
                    throw new FileNotFoundException("File not found.");
            }
        }

        result = fileLines.ToArray();

        return result;
    }

    public string GetSumOfLine(string line)
    {
        string[] elements;
        try
        {
            elements = line.Split(',');
        }
        catch
        {
            return MaxSumConstants.brokenLine;
        }

        decimal sum = 0;
        string result;

        foreach (var i in elements)
        {
            try
            {
                sum += decimal.Parse(i, MaxSumConstants.cultureEN);
            }
            catch
            {
                return MaxSumConstants.brokenLine;
            }
        }

        result = $"{sum}";

        return result;
    }

    public string[] GetSumsInArray(string[] arrayLines)
    {
        var sumList = new List<string>();

        try
        {
            foreach (var line in arrayLines)
            {
                sumList.Add(GetSumOfLine(line));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return sumList.ToArray();
    }

    public decimal GetLargestElementUsingFor(decimal[] sourceArray)
    {
        try
        {
            var maxElement = sourceArray[0];
            for (var i = 1; i < sourceArray.Length; i++)
                if (sourceArray[i] > maxElement)
                {
                    maxElement = sourceArray[i];
                }

            return maxElement;
        }
        catch
        {
            return 0;
        }
    }

    public decimal[] ConvertStringToDecimal(string[] sourceArray)
    {
        var newList = new List<decimal>();

        foreach (var line in sourceArray)
        {
            if (!line.Contains(MaxSumConstants.brokenLine))
            {
                newList.Add(decimal.Parse(line));
            }
            else
            {
                newList.Add(0);
            }
        }

        return newList.ToArray();
    }

    public int[] GetArrayOfMaxSumLines(string[] sourceArray, decimal maxSum)
    {
        var linesList = new List<int>();
        var i = 1;

        foreach (var line in sourceArray)
        {
            try
            {
                if (maxSum == decimal.Parse(line))
                {
                    linesList.Add(i);
                }
            }
            catch (FormatException)
            {
                i++;
                continue;
            }

            i++;
        }

        return linesList.ToArray();
    }
}