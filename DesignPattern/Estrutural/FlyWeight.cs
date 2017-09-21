using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Estrutural
{
    public interface ICoordenadas
    {
        decimal Latitude { get; set; }
        decimal Longitude { get; set; }
        string Endereco { get; set; }
    }

    public class Coordenada : ICoordenadas
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Endereco { get; set; }
        public override string ToString()
        {
            return $"{Endereco} - X: {Longitude} Y: {Latitude}";
        }
    }

    public static class ItinerariosFactory
    {
        private static IList<ICoordenadas> _listaCoordenadas = new List<ICoordenadas>();

        public static ICoordenadas GetCoordenadas(string endereco)
        {
            var existeEndereco = _listaCoordenadas.FirstOrDefault(x => x.Endereco.Contains(endereco));
            if (existeEndereco != null)
                return existeEndereco;

            // buscando endereço e incluido na lista
            var coordenadaEncontrada = new Coordenada { Endereco = endereco, Longitude = Convert.ToDecimal(new Random().Next(60)), Latitude = Convert.ToDecimal(new Random().Next(60)) };
            _listaCoordenadas.Add(coordenadaEncontrada);

            return coordenadaEncontrada;
        }
    }
}
