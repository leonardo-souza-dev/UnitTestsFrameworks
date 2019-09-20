using System;
using System.Collections.Generic;

namespace Calc
{
    public class Calculadora
    {
        public List<Botao> Botoes { get; set; }

        public Calculadora(Botao botao)
        {
            if (botao.Tipo == TipoBotao.LigaDesliga && !botao.Pressionado)
            {
                throw new InvalidOperationException("ligar antes");
            }
        }

        public int Somar(int a, int b)
        {
            return a + b;
        }
    }

    public class Botao
    {
        public virtual bool Pressionado { get; set; }
        public TipoBotao Tipo { get; set; }

        public Botao(TipoBotao tipo)
        {
            this.Tipo = tipo;
        }        
    }

    public enum TipoBotao
    {
        Numero,
        Operacao,
        LigaDesliga
    }
}
