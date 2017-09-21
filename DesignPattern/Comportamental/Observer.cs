using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Comportamental
{
    public class SalaLeilao
    {
        public event Action AlterarLance;

        public void Notificar() => AlterarLance?.Invoke();
    }

    public class LanceObserver
    {
        public decimal Lance { get; set; }

        public void AlteracaoLance() => Console.WriteLine($"Lance = {Lance}");
    }
}
