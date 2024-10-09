namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva()
        {
        }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        private bool VerificarCapacidadeDaSuite(int quantidadeHospedes)
        {
            var capacidadeSuite = Suite.Capacidade;
            return capacidadeSuite >= quantidadeHospedes;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            var quantidadeDeHospedes = hospedes.Count;
            if (VerificarCapacidadeDaSuite(quantidadeDeHospedes))
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentException("Quantidade de hospedes é maior que a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            var quantidadeDeHospedes = Hospedes.Count;

            return quantidadeDeHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valorFinal;

            var calculoBase = DiasReservados * Suite.ValorDiaria;


            if (DiasReservados >= 10)
            {
                var valorDesconto = (calculoBase) * (decimal)0.1;

                valorFinal = calculoBase - valorDesconto;
            }
            else
            {
                valorFinal = calculoBase;
            }


            return valorFinal;
        }
    }
}