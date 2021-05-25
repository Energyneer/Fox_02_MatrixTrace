using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Task2;

namespace Task2test
{
    [TestClass]
    public class UnitTest1
    {
        private Matrix MatrixTest;

        [TestInitialize]
        public void TestInitialize()
        {
            MatrixTest = new Matrix(9, 9);
            int[,] array = { { 11, 23, 33, 45, 91 }, { 43, 58, 69, 90, 2 }, { 73, 88, 93, 2, 45 }, { 3, 5, 66, 77, 13 }, { 32, 88, 1, 91, 16 } };
            MatrixTest.MatrixArray = array;
        }

        [TestMethod]
        public void IncorrectLenght()
        {
            Matrix incorrLenght = new Matrix(-9, -100);
            Assert.AreEqual(1, incorrLenght.MatrixArray.Length);
        }

        [TestMethod]
        public void CorrectLenght()
        {
            Matrix correct = new Matrix(9, 9);
            Assert.AreEqual(81, correct.MatrixArray.Length);
        }

        [TestMethod]
        public void TestTrace()
        {
            Assert.AreEqual(MatrixTest.CalcTraceMatrix(), 255);
        }


        [TestMethod]
        public void TestSnake()
        {
            int[] snake = { 11, 23, 33, 45, 91, 2, 45, 13, 16, 91, 1, 88, 32, 3, 73, 43, 58, 69, 90, 2, 77, 66, 5, 88, 93 };
            Assert.IsTrue(Enumerable.SequenceEqual(snake, MatrixTest.SnakeArray()));
        }
    }
}
