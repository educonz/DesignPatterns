using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Estrutural
{

    public class PortaCOM
    {
        public string ConectarComCOM()
        {
            return "Conectada porta COM";
        }
    }

    public class PortaUSB
    {
        public string ConectarComUSB()
        {
            return "Conectada via usb";
        }
    }

    public class PortaCOMAdapterUSB : PortaCOM
    {
        private readonly PortaCOM _portaCom;

        public PortaCOMAdapterUSB(PortaCOM portaCom)
        {
            _portaCom = portaCom;
        }

        public string ConectarComUSB()
        {
            // aqui fica lógica de conversão
            return $"[USB]-{_portaCom.ConectarComCOM()}";
        }
    }
}
