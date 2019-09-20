using System;

namespace Calc
{
    public class Calculadora
    {
        public Calculadora(Botao botao)
        {
            if (!botao.Pressionado)
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
    }
}
