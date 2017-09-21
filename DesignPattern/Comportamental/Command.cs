using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Comportamental
{
    public interface IOrdemVendaCommand
    {
        void Executar();
    }

    public class TransacaoVenda
    {
        public void Vender()
        {
            // vendendo
        }

        public void Comprar()
        {
            // comprando
        }
    }

    public class Comprar : IOrdemVendaCommand
    {
        private readonly TransacaoVenda _transacao;

        public Comprar(TransacaoVenda transacao)
        {
            _transacao = transacao;
        }

        public void Executar()
        {
            _transacao.Comprar();
        }
    }
    public class Vender : IOrdemVendaCommand
    {
        private readonly TransacaoVenda _transacao;

        public Vender(TransacaoVenda transacao)
        {
            _transacao = transacao;
        }

        public void Executar()
        {
            _transacao.Vender();
        }
    }

    public class ProcessaOrdens
    {
        private IList<IOrdemVendaCommand> _listaOrdemVenda;

        public ProcessaOrdens()
        {
            _listaOrdemVenda = new List<IOrdemVendaCommand>();
        }

        public void AdicionarOrdemVenda(IOrdemVendaCommand ordemVenda) => _listaOrdemVenda.Add(ordemVenda);

        public void ProcessarOrdens() => _listaOrdemVenda.ToList().ForEach(ordem => ordem.Executar());
    }
}
