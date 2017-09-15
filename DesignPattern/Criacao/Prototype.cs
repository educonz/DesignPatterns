namespace DesignPattern.Criacao
{

    public interface ICardPrototype<T>
    {
        T Clone();
    }

    public class CardInsumos : ICardPrototype<CardInsumos>
    {
        public string CodigoMaterialSAP { get; set; }

        public CardInsumos Clone()
        {
            return (CardInsumos)MemberwiseClone();
        }
    }

    public class CardLeilao : ICardPrototype<CardLeilao>
    {
        public string CodigoSolicitacao { get; set; }

        public CardLeilao Clone()
        {
            return (CardLeilao)MemberwiseClone();
        }
    }
}
