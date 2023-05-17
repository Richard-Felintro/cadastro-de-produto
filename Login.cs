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
                //* TELA INCIAL | CADASTRO & LOGIN
                while (Logado == false)
                {
                    MudarMenu("Bem vindo ao sistema de cadastro de produtos\n");
                    Console.WriteLine($"[1] Login");
                    Console.WriteLine($"[2] Cadastrar\n");
                    Console.WriteLine($"[0] Sair");
                    string menuInput = Console.ReadLine();
                    switch (menuInput)
                    {
                        //* LOGIN
                        case "1":
                            MudarMenu("Informe o email do usuário: ");
                            string emailInput = Console.ReadLine();
                            Console.Write($"Informe sua senha: ");
                            string senhaInput = Console.ReadLine();
                            if (Usuario.Logar(emailInput, senhaInput))
                            {
                                MudarMenu("Usuário logado com sucesso!\n");
                                Logado = true;
                                Console.Write($"Aperte ENTER para continuar...");
                                Console.ReadLine();
                            }
                            else
                            {
                                ValorInvalido("Cadastro inválido, login ou senha incorreto");
                            }
                            break;
                        //* CADASTRO
                        case "2":
                            Usuario user = new Usuario(true);
                            break;
                        //* SAIR
                        case "0":
                            MudarMenu("Obrigado por usar o cadastro de produtos de RICARDÃO inc\n");
                            Console.Write($"Aperte ENTER para continuar...");
                            Console.ReadLine();
                            Environment.Exit(1);
                            break;
                        default:
                            ValorInvalido("Opção inválida informada, selecione um valor de 0 a 2.");
                            break;
                    }
                }
                while (Logado)
                {

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
        public void Deslogar(Usuario deslogando)
        {
            Logado = false;
        }
    }
}