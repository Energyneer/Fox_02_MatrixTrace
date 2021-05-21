using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace Task2test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Matrix matrix = new Matrix(-9, -100);
            Assert.AreEqual(1, matrix.MatrixForTest.Length);

            matrix = new Matrix(9, 9);
            Assert.AreEqual(81, matrix.MatrixForTest.Length);
        }
    }
}
