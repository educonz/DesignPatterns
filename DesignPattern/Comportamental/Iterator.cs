using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Comportamental
{
    public interface ITipoCargaIterator
    {
        string Proximo();
    }

    public class TipoCargaIterator : ITipoCargaIterator
    {
        private readonly string[] _tiposCarga;
        private int _index;

        public TipoCargaIterator()
        {
            _tiposCarga = new [] { "Refrigerado", "Terreo", "Aereo" };
            _index = 0;
        }

        public string Proximo()
        {
            var ultimaDaLista = _tiposCarga.Count() - 1 == _index;
            return ultimaDaLista ? _tiposCarga[_index] : _tiposCarga[_index++];
        }
    }
}
