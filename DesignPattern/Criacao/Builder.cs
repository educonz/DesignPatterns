using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Criacao
{
    public interface ITimeDevelopmentSoftwareBuilder
    {
        ITimeDevelopmentSoftwareBuilder AdicionarDev(IDev dev);
        ITimeDevelopmentSoftwareBuilder AdicionarPO(IPO po);
        ITimeDevelopmentSoftwareBuilder AdicionarSM(ISM sm);
    }

    public class TimeDevelopmentSoftwareBuilder : ITimeDevelopmentSoftwareBuilder
    {
        private readonly ICoordenacao _coordenacao;
        private readonly ITime _time;

        private List<IDev> _listadev;
        private List<IPO> _listapo;
        private List<ISM> _listasm;

        public TimeDevelopmentSoftwareBuilder(ICoordenacao coordenacao, ITime time)
        {
            _coordenacao = coordenacao;
            _time = time;
            _listadev = new List<IDev>();
            _listapo = new List<IPO>();
            _listasm = new List<ISM>();
        }

        public ITimeDevelopmentSoftwareBuilder AdicionarDev(IDev dev)
        {
            _listadev.Add(dev);
            return this;
        }

        public ITimeDevelopmentSoftwareBuilder AdicionarPO(IPO po)
        {
            _listapo.Add(po);
            return this;
        }

        public ITimeDevelopmentSoftwareBuilder AdicionarSM(ISM sm)
        {
            _listasm.Add(sm);
            return this;
        }

        public override string ToString()
        {
            var smEmString = string.Join("", _listasm.Select(sm => $"SM: {sm.Nome}\r\n"));
            var poEmString = string.Join("", _listapo.Select(po => $"PO: {po.Nome}\r\n"));
            var devEmString = string.Join("", _listadev.Select(dev => $"DEV: {dev.Nome}\r\n"));

            var stringRetorno =
            $"Time: {_time.Nome}\r\n" +
            $"Coordenação: {_coordenacao.Nome}\r\n" +
             smEmString +
            poEmString +
            devEmString;

            return stringRetorno;
        }
    }

    public interface IDev
    {
        string Nome { get; set; }
    }

    public class Dev : IDev
    {
        public string Nome { get; set; }
    }

    public interface ISM
    {
        string Nome { get; set; }
    }

    public class SM : ISM
    {
        public string Nome { get; set; }
    }

    public interface IPO
    {
        string Nome { get; set; }
    }

    public class PO : IPO
    {
        public string Nome { get; set; }
    }

    public interface ICoordenacao
    {
        string Nome { get; set; }
    }

    public class Coordenacao : ICoordenacao
    {
        public string Nome { get; set; }
    }

    public interface ITime
    {
        string Nome { get; set; }
    }

    public class Time : ITime
    {
        public string Nome { get; set; }
    }
}
