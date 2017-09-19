using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Estrutural
{

    public class SolicitacaoFreteFacade
    {
        private readonly IConvocaoTransportadora _convocaTransportadora;
        private readonly IControleEmail _controleEmail;
        private readonly IControleSessao _controleSessao;
        private readonly ILog _log;

        public SolicitacaoFreteFacade(
            IConvocaoTransportadora convocaTransportadora,
            IControleEmail controleEmail,
            IControleSessao controleSessao,
            ILog log)
        {
            _convocaTransportadora = convocaTransportadora;
            _controleEmail = controleEmail;
            _controleSessao = controleSessao;
            _log = log;
        }

        public void PrepararEIniciarSessao()
        {
            _log.RegistraLog("Iniciando processo de inicio de sessão!");
            _convocaTransportadora.BuscarTransportadoras();
            _convocaTransportadora.SelecionarRankingTransportadoras();
            _controleEmail.EnviarEmailParaTransportadoras();
            _controleSessao.IniciarSessao();
            _log.RegistraLog("Sessão iniciada com sucesso!");
        }
    }

    public interface ILog
    {
        void RegistraLog(string log);
    }

    public interface IControleSessao
    {
        void IniciarSessao();
    }

    public interface IControleEmail
    {
        void EnviarEmailParaTransportadoras();
    }

    public interface IConvocaoTransportadora
    {
        void BuscarTransportadoras();
        void SelecionarRankingTransportadoras();
    }
}
