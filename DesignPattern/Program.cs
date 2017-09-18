using DesignPattern.Criacao;
using DesignPattern.Estrutural;
using System;

namespace DesignPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //BuilderTest();
            //FactoryTest();
            //AbstractFactoryTest();
            //SingletonTest();
            //PrototypeTest();

            //AdapterTest();
            CompositeTest();
        }

        private static void CompositeTest()
        {
            var rota = new Rota()
            {
                Origem = "Blumenau",
                Destino = "Maringá"
            };

            rota.AdicionarPontoParada(new PontoParada
            {
                Origem = "Blumenau",
                Destino = "Curitiba"
            });

            rota.AdicionarPontoParada(new PontoParada
            {
                Origem = "Curitiba",
                Destino = "Ortigueira"
            });

            rota.AdicionarPontoParada(new PontoParada
            {
                Origem = "Ortigueira",
                Destino = "Maringá"
            });

            Console.WriteLine(rota.ObterRota());
            Console.ReadKey();
        }

        private static void AdapterTest()
        {
            Console.WriteLine($"Cenerário anterior");
            var portaCom = new PortaCOM();
            Console.WriteLine($"{portaCom.ConectarComCOM()}");

            Console.WriteLine($"Cenerário novo: o dispositivo só aceita usb");
            var adapterCom = new PortaCOMAdapterUSB(new PortaCOM());
            Console.WriteLine($"{adapterCom.ConectarComUSB()}");
            Console.ReadKey();
        }

        public static void BuilderTest()
        {
            var time = new TimeDevelopmentSoftwareBuilder(new Coordenacao { Nome = "Thays" }, new Time { Nome = "Procurement" });
            time.AdicionarPO(new PO { Nome = "Andressa" })
                .AdicionarPO(new PO { Nome = "Mainha" })
                .AdicionarSM(new SM { Nome = "Ronaldo brilha muito no Corinthians" })
                .AdicionarSM(new SM { Nome = "Pradelicia das indias" })
                .AdicionarDev(new Dev { Nome = "Conz" })
                .AdicionarDev(new Dev { Nome = "Matheus" });

            Console.WriteLine(time.ToString());
            Console.ReadKey();
        }

        public static void FactoryTest()
        {
            var portalCreator = new ProcurementPortalCreatorFactory();

            Console.WriteLine(portalCreator.ObterPortal(TipoPortalProcurement.Insumos).Descricao);
            Console.WriteLine(portalCreator.MeVeInstanciaPortalPagamentos().Descricao);
            Console.ReadKey();
        }

        public static void AbstractFactoryTest()
        {
            var hbControleDeTime = new HBSISControleTimeAbstractFactory();

            var centroCustoProcurement = hbControleDeTime.ConsultarCentroCustoPorTime(new TimeProcuremntFactory());
            var centroCustoWMS = hbControleDeTime.ConsultarCentroCustoPorTime(new TimeWMSFactory());

            Console.WriteLine($"{centroCustoProcurement.Descricao} - PASSIVO: {centroCustoProcurement.TotalPassivo}");
            Console.WriteLine($"{centroCustoWMS.Descricao} - PASSIVO: {centroCustoWMS.TotalPassivo}");
            Console.ReadKey();
        }

        public static void SingletonTest()
        {
            Configuracao.Instancia.ConexaoBanco = "DB=TESTE;USER=TESTE;PASS=TESTE";
            Console.WriteLine(Configuracao.Instancia.ConexaoBanco);
            Console.ReadKey();
        }

        public static void PrototypeTest()
        {
            var cardInsumos = new CardInsumos
            {
                CodigoMaterialSAP = "000123"
            };

            var cloneCardInsumos = cardInsumos.Clone();

            var cardLeilao = new CardLeilao
            {
                CodigoSolicitacao = "SOL-001"
            };

            var cloneCardLeilao = cardLeilao.Clone();

            Console.WriteLine($"Card insumos -> {cloneCardInsumos.CodigoMaterialSAP}");
            Console.WriteLine($"Card leilao -> {cloneCardLeilao.CodigoSolicitacao}");
            Console.ReadKey();
        }
    }
}
