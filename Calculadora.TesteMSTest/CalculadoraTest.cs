using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;

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
            var botao = new Botao(TipoBotao.LigaDesliga);
            botao.Pressionado = true;
            var calculadora = new Calculadora(botao);

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
            var botao = new Botao(TipoBotao.LigaDesliga);
            var calculadora = new Calculadora(botao);

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
            var botao = new Botao(TipoBotao.LigaDesliga);

            //act
            //assert
            new Calculadora(botao);
        }

        /// <summary>
        /// Teste com mock. Setup de propriedade
        /// </summary>
        [TestMethod]
        public void Deve_Ligar_Com_Mock_E_Setup_De_Propriedade()
        {
            //arrange
            var mock = new Mock<Botao>(TipoBotao.LigaDesliga);
            mock.Setup(x => x.Pressionado).Returns(true);

            //act
            var calculadora = new Calculadora(mock.Object);

            //assert
            Assert.IsNotNull(calculadora);
        }

        /// <summary>
        /// Teste com mock com construtor
        /// </summary>
        [TestMethod]
        public void Deve_Ligar()
        {
            //arrange
            var mock = new Mock<Botao>(TipoBotao.LigaDesliga);

            mock.Setup(x => x.Pressionado).Returns(true);

            //act
            var calculadora = new Calculadora(mock.Object);

            //assert
            Assert.IsNotNull(calculadora);
        }

        [TestMethod]
        public void Deve_Somar_1_com_2_E_Dar_3_Usando_FluentAssertions()
        {
            //arrange
            var botao = new Botao(TipoBotao.LigaDesliga);
            botao.Pressionado = true;
            var calculadora = new Calculadora(botao);

            //act
            var resultado = calculadora.Somar(1, 2);

            //assert
            resultado.Should().Be(3);
        }
    }
}
