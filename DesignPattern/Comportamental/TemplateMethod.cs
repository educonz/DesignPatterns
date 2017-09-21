using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Comportamental
{
    public abstract class ImportacaoPlanilha
    {
        public void ImportarEProcessarPlanilha(string path)
        {
            var arquivoEncontrado = ImportarArquivo(path);
            ProcessarDadosEncontrados(arquivoEncontrado);
        }

        public object ImportarArquivo(string path)
        {
            return new { };
        }

        public abstract void ProcessarDadosEncontrados(object dadosPlanilha);
    }

    public class PlanilhaUnidadesNegocio : ImportacaoPlanilha
    {
        public override void ProcessarDadosEncontrados(object dadosPlanilha)
        {
            // Processando dados unidade negócio
        }
    }

    public class PlanilhaMaterial : ImportacaoPlanilha
    {
        public override void ProcessarDadosEncontrados(object dadosPlanilha)
        {
            // Processando dados materiais
        }
    }
}
