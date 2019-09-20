using System;
using NUnit.Framework;
using Moq;

namespace Calc.TesteNUnit
{

    public class CalculadoraTest
    {
        /// <summary>
        /// Teste unitário simples com classe concreta
        /// </summary>
        [Test]
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
        [Test]
        [TestCase(1, 2)]
        public void Deve_Somar_1_com_2_e_dar_3(int a, int b)
        {
            //arrange
            var calculadora = new Calculadora(new Botao { Pressionado = true });

            //act
            var resultado = calculadora.Somar(a, b);

            //assert
            Assert.AreEqual(3, resultado);
        }

        /// <summary>
        /// Teste unitário com exceção
        /// </summary>
        [Test]
        public void Deve_Dar_Erro_Ao_Ligar()
        {

            //arrange
            //act
            //assert
            Assert.Throws<InvalidOperationException>(() => new Calculadora(new Botao { Pressionado = false }));
        }

        /// <summary>
        /// Test com mock
        /// </summary>
        [Test]
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