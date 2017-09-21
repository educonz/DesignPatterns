using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Comportamental
{
    public interface ISessaoState
    {
        void Acao(ContextoSessao contexto);
    }

    public class SessaoIniciada : ISessaoState
    {
        public void Acao(ContextoSessao contexto)
        {
            contexto.EstadoSessao = this;
        }

        public override string ToString()
        {
            return "Sessão foi iniciada";
        }
    }

    public class SessaoConcluida : ISessaoState
    {
        public void Acao(ContextoSessao contexto)
        {
            contexto.EstadoSessao = this;
        }

        public override string ToString()
        {
            return "Sessão foi concluida";
        }
    }

    public class SessaoCancelada : ISessaoState
    {
        public void Acao(ContextoSessao contexto)
        {
            contexto.EstadoSessao = this;
        }

        public override string ToString()
        {
            return "Sessão foi cancelada";
        }
    }

    public class ContextoSessao
    {
        public ISessaoState EstadoSessao { get; set; }
    }
}
