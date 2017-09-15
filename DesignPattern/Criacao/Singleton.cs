namespace DesignPattern.Criacao
{
    public class Configuracao
    {
        public string ConexaoBanco { get; set; }

        private Configuracao()
        {
        }

        private static Configuracao _instancia = new Configuracao();
        public static Configuracao Instancia => _instancia;
    }
}
