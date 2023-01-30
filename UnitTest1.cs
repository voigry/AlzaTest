using System.Diagnostics;
using System.Globalization;

namespace TestProjectNunit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Testing writeline");
            Assert.Pass();
            
        }

        [Test]
        public void test2()
        {

            TestContext.Out.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}");
            /*
            Debug.WriteLine("This is Debug.WriteLine");
            Trace.WriteLine("This is Trace.WriteLine");
            Console.WriteLine("This is Console.Writeline");
            TestContext.WriteLine("This is TestContext.WriteLine");
            TestContext.Out.WriteLine("This is TestContext.Out.WriteLine");
            TestContext.Progress.WriteLine("This is TestContext.Progress.WriteLine");
            TestContext.Error.WriteLine("This is TestContext.Error.WriteLine");
            Debug.WriteLine(TestContext.CurrentContext.WorkDirectory.ToString());
            */
            Assert.True(true, "Should be true.");
            Assert.Pass();
        }

        [Test]
        public void test3()
        {
            var value = TestContext.Parameters["someParameterName"];
            Debug.WriteLine($"{value}");
        }
    }

}

