using DesignPattern.Criacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Estrutural
{
    public abstract class PortalBaseDecorator : Portal
    {
        public abstract void EmprestarAnalista();
    }

    public class Comex : PortalBaseDecorator
    {
        public override string Descricao => "Comex";

        public override void EmprestarAnalista()
        {
            // emprestando analista
        }
    }
}
