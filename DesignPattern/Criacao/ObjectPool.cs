using System;
using System.Collections.Generic;

namespace DesignPattern.Criacao
{
    public interface IControleInstancia<T>
    {
        T ObterInstancia();
        void LiberarInstancia(T t);
    }

    public class LanceLeilaoControleInstancia : IControleInstancia<LanceLeilao>
    {
        private List<LanceLeilao> _lances;
        private readonly int _maximoInstancia;

        public LanceLeilaoControleInstancia(int maximoInstancia)
        {
            _lances = new List<LanceLeilao>();
            _maximoInstancia = maximoInstancia;
        }

        public void LiberarInstancia(LanceLeilao lance)
        {
            _lances.Remove(lance);
        }

        public LanceLeilao ObterInstancia()
        {
            if (_lances.Count < _maximoInstancia)
            {
                var lanceLeilao = new LanceLeilao();
                _lances.Add(lanceLeilao);
                return lanceLeilao;
            }

            throw new Exception("Você não pode furar a fila, aguarde sua vez!");
        }
    }

    public class LanceLeilao
    {


        public decimal Lance { get; set; }
        public string Usuario { get; set; }
    }
}
