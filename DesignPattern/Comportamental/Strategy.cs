using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Comportamental
{
    public class Card
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }

    public interface ICardStrategy
    {
        Card ObterCard();
    }

    public class CardSessao : ICardStrategy
    {
        public Card ObterCard()
        {
            return new Card();
        }
    }

    public class CardSolicitacao : ICardStrategy
    {
        public Card ObterCard()
        {
            return new Card();
        }
    }

    public class CardService
    {
        private readonly ICardStrategy _cardStrategy;

        public CardService(ICardStrategy cardStrategy)
        {
            _cardStrategy = cardStrategy;
        }

        public Card GetCard() => _cardStrategy.ObterCard();
    }
}
