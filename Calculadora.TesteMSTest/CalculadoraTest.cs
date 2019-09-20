using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Calc.TesteMSTest
{
    [TestClass]
    public class CalculadoraTest
    {
        /// <summary>
        /// Teste unitário simples com classe concreta
        /// </summary>
        [TestMethod]
        public void Deve_Somar_1_com_2_e_dar_3()
        {
            //arrange
            var calculadora = new Calculadora(new Botao { Pressionado = true });

            //act
            var resultado = calculadora.Somar(1, 2);

            //assert
            Assert.AreEqual(3, resultado);
        }

        /// <summary>
        /// Teste unitário passando parâmetros via decorator
        /// </summary>
        /// <param name="a">Primeiro elemento</param>
        /// <param name="b">Segundo elemento</param>
        [DataTestMethod]
        [DataRow(1, 2)]
        public void Deve_Somar_1_com_2_e_dar_3(int a, int b)
        {
            //arrange
            var calculadora = new Calculadora(new Botao { Pressionado = true });

            //act
            var resultado = calculadora.Somar(a, b);

            //assert
            Assert.AreEqual(4, resultado);//ERA PRA MOSTRAR O ERRO
        }

        /// <summary>
        /// Teste unitário com exceção
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Deve_Dar_Erro_Ao_Ligar()
        {
            //arrange
            //act
            //assert
            new Calculadora(new Botao());
        }

        /// <summary>
        /// Teste com mock
        /// </summary>
        [TestMethod]
        public void Deve_Ligar()
        {
            //arrange
            var mock = new Mock<Botao>();
            mock.Setup(x => x.Pressionado).Returns(true);

            //act
            var calculadora = new Calculadora(mock.Object);

            //assert
            Assert.IsNotNull(calculadora);
        }
    }
}
