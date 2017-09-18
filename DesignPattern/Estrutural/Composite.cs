using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Estrutural
{
    public interface IItinerario
    {
        string Origem { get; set; }
        string Destino { get; set; }

        string ObterRota();
    }

    public class PontoParada : IItinerario
    {
        public string Origem { get; set; }
        public string Destino { get; set; }

        public string ObterRota()
        {
            return $"Inicia:{Origem} - Para:{Destino}";
        }
    }

    public class Rota : IItinerario
    {
        private List<PontoParada> _pontosParada = new List<PontoParada>();

        public void AdicionarPontoParada(PontoParada pontoParada)
        {
            _pontosParada.Add(pontoParada);
        }

        public string ObterRota()
        {
            var paradas = (_pontosParada.Count > 0)
                ? "Paradas:\n" + string.Join("", _pontosParada.Select(ponto => $"   {ponto.ObterRota()}\n"))
                : string.Empty;

            return $"Iniciar:{Origem}\n {paradas} Destino Final: {Destino}";
        }

        public string Origem { get; set; }
        public string Destino { get; set; }
    }
}
