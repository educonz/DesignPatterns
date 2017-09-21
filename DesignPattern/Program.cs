using DesignPattern.Comportamental;
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
            //CompositeTest();
            //FlyWeightTest();

            //ObserverTest();
            //MediatorTest();
            StateTest();
        }

        private static void StateTest()
        {
            var contextoSessao = new ContextoSessao();

            new SessaoIniciada().Acao(contextoSessao);
            Console.WriteLine(contextoSessao.EstadoSessao.ToString());

            new SessaoConcluida().Acao(contextoSessao);
            Console.WriteLine(contextoSessao.EstadoSessao.ToString());
            Console.ReadKey();

        }

        private static void MediatorTest()
        {
            new Usuario() { Nome = "Conz" }.EnviarMensagem("Olá");
            new Usuario() { Nome = "Aline" }.EnviarMensagem("Aqui!");
            new Usuario() { Nome = "Prado" }.EnviarMensagem("Pradelicia!");
            Console.ReadKey();
        }

        private static void FlyWeightTest()
        {
            var coordenada1 = ItinerariosFactory.GetCoordenadas("Blumenau");
            var coordenada2 = ItinerariosFactory.GetCoordenadas("Maringá");
            var coordenada3 = ItinerariosFactory.GetCoordenadas("Blumenau");

            Console.WriteLine($"coordenada1 => {coordenada1.ToString()}");
            Console.WriteLine($"coordenada2 => {coordenada2.ToString()}");
            Console.WriteLine($"coordenada3 => {coordenada3.ToString()}");
            Console.ReadKey();
        }

        private static void ObserverTest()
        {
            var salaLeilao = new SalaLeilao();

            salaLeilao.AlterarLance += new LanceObserver { Lance = 100 }.AlteracaoLance;
            salaLeilao.AlterarLance += new LanceObserver { Lance = 1500 }.AlteracaoLance;
            salaLeilao.AlterarLance += new LanceObserver { Lance = 500 }.AlteracaoLance;

            salaLeilao.Notificar();
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
