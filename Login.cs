using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_de_produto
{
    public class Login
    {
        //* Atributos
        private bool Logado = false;

        //* Construtor
        public Login()
        {
            bool loopInfinito = true;
            while (loopInfinito)
            {
                MudarMenu("Bem vindo ao sistema de cadastro de produtos\n");
                Console.WriteLine($"[1] Login");
                Console.WriteLine($"[2] Cadastrar\n");
                Console.WriteLine($"[0] Sair");
                string menuInput = Console.ReadLine();
                switch (menuInput)
                {
                    case "1":
                        //* Logar();
                        break;
                    case "2":
                        Usuario user = new Usuario();
                        break;
                    case "0":
                    MudarMenu("Obrigado por usar o cadastro de produtos de RICARDÃO inc");
                    Console.Write($"Aperte ENTER para continuar...");
                    Console.ReadLine();
                    Environment.Exit(1);
                        break;
                    default:
                        break;
                }
            }
        }
        //* Métodos
        public static void MudarMenu(string subtitulo)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Cadastro de Produtos");
            Console.ResetColor();
            Console.Write($"{subtitulo}");
        }
        public static void ValorInvalido(string subtitulo)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Cadastro de Produtos");
            Console.ResetColor();
            Console.WriteLine($"{subtitulo}");
            Console.Write($"Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void Logar(Usuario user)
        {
            MudarMenu("Informe o seu email ou nome de usuário: ");
            string loginInput = Console.ReadLine();

        }

        public void Deslogar(Usuario user)
        {
        }

    }
}