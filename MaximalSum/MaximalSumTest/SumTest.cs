using MaximalSum;

namespace MaximalSumTest;

public class UnitTest1
{
    private readonly Logic lg = new();

    [Theory]
    [InlineData("50.48, 86.56, 27.06, 69.71, 63.55", "297,36")]
    [InlineData("0", "0")]
    [InlineData(null, "Broken line.")]
    [InlineData("-20, 86, -27, 69, 63", "171")]
    [InlineData("7.7988657293836, 1.37258044647639", "9,17144617585999")]
    [InlineData("47, 3, 54, 61, 37, 57, 29, 52, 18, 8, 73, 52, 95, 61, 69, 16, 33, 76, 73, 37", "951")]
    [InlineData("1,2,2,3,4,5", "17")]
    [InlineData("1.1,2.2,2,3.3,4,5.4", "18,0")]
    [InlineData(" ", "Broken line.")]
    [InlineData("                                                                              ", "Broken line.")]
    public void MaximalSumOfLine(string line, string expectedResult)
    {
        var result = lg.GetSumOfLine(line);
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GetMaxValueFromArray1()
    {
        var line = new decimal[] { 92, 64, 5, 86, 42 };
        var result = lg.GetLargestElementUsingFor(line);
        Assert.Equal(92, result);
    }

    [Fact]
    public void GetMaxValueFromArray2()
    {
        var line = new decimal[] { };
        var result = lg.GetLargestElementUsingFor(line);
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetMaxValueFromArray3()
    {
        var result = lg.GetLargestElementUsingFor(null);
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetAllSumsInArray1()
    {
        string[] array =
        {
            "92, 64, 5, 86, 42", "-20, 86, -27, 69, 63", "0", "50.48, 86.56, 27.06, 69.71, 63.55", "1.1,2.2,2,3.3,4,5.4"
        };
        string[] resultArray = { "289", "171", "0", "297,36", "18,0" };

        Assert.Equal(resultArray, lg.GetSumsInArray(array));
    }

    [Fact]
    public void GetAllSumsInArray2()
    {
        string[] array = null;
        string[] result = new string[0];
        Assert.Equal(result, lg.GetSumsInArray(array));
    }

    [Fact]
    public void GetAllSumsInArray3()
    {
        string[] array = { "0" };
        string[] resultArray = { "0" };
        Assert.Equal(resultArray, lg.GetSumsInArray(array));
    }
}