using System;
using NUnit.Framework;
using Moq;
using FluentAssertions;

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
        [Test]
        [TestCase(1, 2)]
        public void Deve_Somar_1_com_2_e_dar_3(int a, int b)
        {
            //arrange
            var botao = new Botao(TipoBotao.LigaDesliga);
            botao.Pressionado = true;
            var calculadora = new Calculadora(botao);

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
            var botao = new Botao(TipoBotao.LigaDesliga);

            //act
            //assert
            Assert.Throws<InvalidOperationException>(() => new Calculadora(botao));
        }

        /// <summary>
        /// Teste com mock. Setup de propriedade
        /// </summary>
        [Test]
        public void Deve_Ligar_Com_Mock_E_Setup_De_Propriedade()
        {
            //arrange
            var botao = new Mock<Botao>(TipoBotao.LigaDesliga);
            botao.Setup(x => x.Pressionado).Returns(true);

            //act
            var calculadora = new Calculadora(botao.Object);

            //assert
            Assert.IsNotNull(calculadora);
        }

        /// <summary>
        /// Test com mock com construtor
        /// </summary>
        [Test]
        public void Deve_Ligar()
        {
            //arrange
            var mock = new Mock<Botao>(TipoBotao.LigaDesliga);
            //mock.Object.Pressionado = true; //NÃO FUNCIONA
            mock.Setup(x => x.Pressionado).Returns(true);

            //act
            var calculadora = new Calculadora(mock.Object);

            //assert
            Assert.IsNotNull(calculadora);
        }

        [Test]
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