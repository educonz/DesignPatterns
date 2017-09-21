using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Comportamental
{
    public class Chat 
    {
        public static void Enviar(Usuario usuario, string mensagem)
        {
            Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm")} - [{usuario.Nome}] - {mensagem}");
        }
    }

    public class Usuario
    {
        public string Nome { get; set; }

        public void EnviarMensagem(string mensagem) => Chat.Enviar(this, mensagem);
    }
}
