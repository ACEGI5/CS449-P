using NineMansMorrisLib;
using NUnit.Framework;

namespace NineMansMorrisUiTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var test = new Board();
            Assert.NotNull(test);
        }
    }
}