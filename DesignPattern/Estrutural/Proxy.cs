using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Estrutural
{
    public interface IConta
    {
        decimal ConsultarSaldo();
        void Depositar(decimal valor);
        void Sacar(decimal valor);
    }

    public class ContaPoupanca : IConta
    {
        public decimal ConsultarSaldo()
        {
            return 1000;
        }

        public void Depositar(decimal valor)
        {
        }

        public void Sacar(decimal valor)
        {
        }
    }

    public class ContaPoupancaProxy : IConta
    {
        private readonly ContaPoupanca _contaPoupanca;

        public ContaPoupancaProxy(ContaPoupanca contaPoupanca)
        {
            _contaPoupanca = contaPoupanca;
        }

        public decimal ConsultarSaldo()
        {
            return _contaPoupanca.ConsultarSaldo();
        }

        public void Depositar(decimal valor)
        {
            if (valor > 2000)
                throw new Exception("Valor não permitido para depósito!");

            _contaPoupanca.Depositar(valor);
        }

        public void Sacar(decimal valor)
        {
            if (valor > 2000)
                throw new Exception("Valor não permitido para saque!");

            _contaPoupanca.Sacar(valor);
        }
    }
}
