using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Estrutural
{
    public interface IDocumento
    {
        void GerarArquivo(string conteudo);
    }

    public class Planilha : IDocumento
    {
        private readonly IGeradorArquivo _gerador;

        public Planilha(IGeradorArquivo gerador)
        {
            _gerador = gerador;
        }

        public void GerarArquivo(string conteudo)
        {
            _gerador.Gerar(conteudo);
        }
    }

    public interface IGeradorArquivo
    {
        void Gerar(string conteudo);
    }

    public class GeradorArquivoLibMicrosoft : IGeradorArquivo
    {
        public void Gerar(string conteudo)
        {
        }
    }

    public class GeradorArquivoLibOpenOffice : IGeradorArquivo
    {
        public void Gerar(string conteudo)
        {
        }
    }

    // Exemplo de utilização
    // Com isso podemos passar qualquer tipo de documento (ex: Planinha, Word, Apresentacao)
    public class ExportarDocumentoSessoes
    {
        public void GerarDocumento(IDocumento documento, string conteudo)
        {
            documento.GerarArquivo(conteudo);
        }
    }
}
