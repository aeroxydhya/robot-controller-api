using Xunit;

public class BasicTests
{
    [Fact]
    public void Test_Addition_ShouldWork()
    {
        int result = 2 + 2;
        Assert.Equal(4, result);
    }
}