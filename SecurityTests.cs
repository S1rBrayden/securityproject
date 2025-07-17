
[TestClass]
public class SecurityTests
{
    [TestMethod]
    public void Test_XSS_Sanitization()
    {
        var input = "<script>alert('xss')</script>";
        var encoded = System.Net.WebUtility.HtmlEncode(input);
        Assert.IsFalse(encoded.Contains("<script>"));
    }

    [TestMethod]
    public void Test_SQLInjection_Prevention()
    {
        var input = "' OR 1=1 --";
        var isSafe = !input.Contains("'") && !input.Contains("--");
        Assert.IsTrue(isSafe);
    }
}
