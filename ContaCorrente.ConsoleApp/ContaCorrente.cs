namespace ContaCorrente.ConsoleApp
{
    public partial class ContaCorrente
    {
        public int numero { get; set; }
        public double saldo { get; set; }
        public double limite { get; set; }
        public bool ehEspecial { get; set; }
        public Movimentacao[] movimentacoes { get; set; }
        private int indiceMovimentacoes { get; set; }

        public ContaCorrente()
        {
            saldo = 0;
            indiceMovimentacoes = 0;
            movimentacoes = new Movimentacao[10];
        }

        public void Sacar(double valor)
        {
            if (valor > 0 && (saldo + limite) >= valor)
            {
                saldo -= valor;
                movimentacoes[indiceMovimentacoes++] = new Movimentacao(valor, TipoMovimentacao.Debito);
            }
        }

        public void Depositar(double valor)
        {
            if (valor > 0)
            {
                saldo += valor;
                movimentacoes[indiceMovimentacoes++] = new Movimentacao(valor, TipoMovimentacao.Credito);
            }
        }

        public void TransferirPara(ContaCorrente outraConta, double valor)
        {
            if (valor > 0 && (saldo + limite) >= valor)
            {
                saldo -= valor;
                movimentacoes[indiceMovimentacoes++] = new Movimentacao(valor, TipoMovimentacao.Debito);

                outraConta.Depositar(valor);
                outraConta.movimentacoes[outraConta.indiceMovimentacoes++] = new Movimentacao(valor, TipoMovimentacao.Credito);
            }
        }

        public void ExibirSaldo()
        {
            Console.WriteLine("Saldo: " + saldo);
        }

        public void ExibirExtrato()
        {
            Console.WriteLine("Extrato:");
            foreach (var movimentacao in movimentacoes)
            {
                if (movimentacao == null) break;
                Console.WriteLine(movimentacao.tipo + ": " + movimentacao.valor);
            }
        }
    }
}