using Microsoft.AspNetCore.Html;
using Ganss.Xss;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using RazorPetTreats.SharedServices;

namespace RazorPetTreats.Tests
{
    [TestClass]
    public sealed class SafeTest
    {
        [TestMethod]
        public void Safe_CanRawEncode()
        {
            var htmlSanitizer = new HtmlSanitizer();
            var mockJsonHelper = new Mock<IJsonHelper>();
            var moqHtmlHelper = new Mock<IHtmlHelper>();
            moqHtmlHelper.Setup(m => m.Raw(It.IsAny<string>())).Returns((string s) => new HtmlString(s));

            var converter = new Safe(moqHtmlHelper.Object, mockJsonHelper.Object, htmlSanitizer);

            var actualText = "Hello<script>alert('Hello')</script>World";

            var result = converter.Raw(actualText);

            Assert.AreEqual("HelloWorld", result.ToString());
        }
    }
}
