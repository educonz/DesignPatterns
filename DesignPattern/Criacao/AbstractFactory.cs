namespace DesignPattern.Criacao
{
    public interface ICentroCusto
    {
        decimal TotalPassivo { get; }
        string Descricao { get; }
    }

    public class CentroCustoProcurement : ICentroCusto
    {
        public decimal TotalPassivo => 150000.00M;
        public string Descricao => "Procurement";
    }

    public class CentroCustoWMS : ICentroCusto
    {
        public decimal TotalPassivo => 10000.00M;
        public string Descricao => "WMS";
    }

    public interface ITimeFactory
    {
        ICentroCusto ObterCentroCusto();
    }

    public class TimeProcuremntFactory : ITimeFactory
    {
        public ICentroCusto ObterCentroCusto()
        {
            return new CentroCustoProcurement();
        }
    }

    public class TimeWMSFactory : ITimeFactory
    {
        public ICentroCusto ObterCentroCusto()
        {
            return new CentroCustoWMS();
        }
    }

    public class HBSISControleTimeAbstractFactory
    {
        public ICentroCusto ConsultarCentroCustoPorTime(ITimeFactory factory)
        {
            return factory.ObterCentroCusto();
        }
    }
}
