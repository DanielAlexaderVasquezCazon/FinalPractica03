using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaFinal8.Controllers;

namespace UnitTestSumita
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesAdd1()
        {
            //Arrange
            SumasController sumasController = new SumasController();
            int a = 1;
            int b = 4;
            int esperado = 5;
            //Act
            int resultado = sumasController.Add(a, b);
            //Accert
            Assert.AreEqual(esperado, resultado);

            
        }
    }
}
