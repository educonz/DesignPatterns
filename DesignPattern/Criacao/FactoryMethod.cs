using System;

namespace DesignPattern.Criacao
{
    public abstract class Portal
    {
        public abstract string Descricao { get; }
    }

    public class Leilao : Portal
    {
        public override string Descricao => "Portal leilão";
    }

    public class Pagamentos : Portal
    {
        public override string Descricao => "Portal pagamentos";
    }

    public class Insumos : Portal
    {
        public override string Descricao => "Portal insumos";
    }

    public class ProcurementPortalCreatorFactory
    {
        public Portal MeVeInstanciaPortalPagamentos()
        {
            return new Pagamentos();
        }

        public Portal ObterPortal(TipoPortalProcurement tipoPortal)
        {
            switch (tipoPortal)
            {
                case TipoPortalProcurement.Leilao:
                    return new Leilao();
                case TipoPortalProcurement.Pagamentos:
                    return new Pagamentos();
                case TipoPortalProcurement.Insumos:
                    return new Insumos();
                default:
                    throw new Exception("Portal não suportado");
            }
        }
    }

    public enum TipoPortalProcurement
    {
        Leilao,
        Pagamentos,
        Insumos
    }
}
