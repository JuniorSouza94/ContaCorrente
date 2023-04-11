using static ContaCorrente.ConsoleApp.ContaCorrente;

namespace ContaCorrente.ConsoleApp
{
    public class Movimentacao
    {
        public double valor { get; set; }
        public TipoMovimentacao tipo { get; set; }

        public Movimentacao(double valor, TipoMovimentacao tipo)
        {
            this.valor = valor;
            this.tipo = tipo;
        }
    }
}