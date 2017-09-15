using DesignPattern.Criacao;
using System;

namespace DesignPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //SingletonTest();
            ObjectPoolTest();
            //PrototypeTest();
        }

        public static void ObjectPoolTest()
        {
            var controleDeLances = new LanceLeilaoControleInstancia(2);

            var usuario1 = controleDeLances.ObterInstancia();
            usuario1.Usuario = "USUARIO1";
            usuario1.Lance = 100;

            Console.WriteLine($"{usuario1.Usuario} - {usuario1.Lance}");

            var usuario2 = controleDeLances.ObterInstancia();
            usuario2.Usuario = "USUARIO2";
            usuario2.Lance = 200;

            Console.WriteLine($"{usuario2.Usuario} - {usuario2.Lance}");


            try
            {
                var usuario3 = controleDeLances.ObterInstancia();
                usuario3.Usuario = "USUARIO3";
                usuario3.Lance = 300;

                Console.WriteLine($"{usuario3.Usuario} - {usuario3.Lance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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
