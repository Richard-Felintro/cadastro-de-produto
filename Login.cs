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
                while (Logado == false)
                // *************************************** //
                // *   TELA INICIAL | CADASTRO & LOGIN   * //
                // *************************************** //
                {
                    Funcionalidades.MudarMenu("Bem vindo ao sistema de cadastro de produtos\n");
                    Console.WriteLine($"[1] Login");
                    Console.WriteLine($"[2] Cadastrar\n");
                    Console.WriteLine($"[0] Sair");
                    string loginMenuInput = Console.ReadLine();
                    switch (loginMenuInput)
                    {
                        //* LOGIN
                        case "1":
                            Funcionalidades.MudarMenu("Informe o email do usuário: ");
                            string emailInput = Console.ReadLine();
                            Console.Write($"Informe sua senha: ");
                            string senhaInput = Console.ReadLine();
                            if (Usuario.Logar(emailInput, senhaInput))
                            {
                                Funcionalidades.MudarMenu("Usuário logado com sucesso!\n");
                                Logado = true;
                                Console.Write($"Aperte ENTER para continuar...");
                                Console.ReadLine();
                            }
                            else
                            {
                                Funcionalidades.ValorInvalido("Cadastro inválido, login ou senha incorreto");
                            }
                            break;
                        //* CADASTRO
                        case "2":
                            Usuario user = new Usuario(true);
                            break;
                        //* SAIR
                        case "0":
                            Funcionalidades.MudarMenu("Obrigado por usar o cadastro de produtos de RICARDÃO inc\n");
                            Console.Write($"Aperte ENTER para continuar...");
                            Console.ReadLine();
                            Environment.Exit(1);
                            break;
                        default:
                            Funcionalidades.ValorInvalido("Opção inválida informada, selecione um valor de 0 a 2.");
                            break;
                    }
                }
                while (Logado)
                {
                    Marca main = new Marca(true);
                    // *************************************** //
                    // *   TELA PRINCIPAL | USUÁRIO LOGADO   * //
                    // *************************************** //
                    Funcionalidades.MudarMenu("Menu principal");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($@"Gerenciar Produtos");
                    Console.ResetColor();
                    Console.WriteLine($"[1] Cadastrar Produtos");
                    Console.WriteLine($"[2] Remover Produtos");
                    Console.WriteLine($"[3] Listar Produtos");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Gerenciar Marcas");
                    Console.ResetColor();
                    Console.WriteLine($"[4] Cadastrar Marcas");
                    Console.WriteLine($"[5] Remover Marcas");
                    Console.WriteLine($"[6] Listar Marcas");

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Gerenciar Conta");
                    Console.ResetColor();
                    Console.WriteLine($"[9] Editar sua conta");
                    Console.WriteLine($"[0] Sair de sua conta");
                    string mainMenuInput = Console.ReadLine();
                    switch (mainMenuInput)
                    {
                        //* Gerenciar produtos
                        case "1": //* Cadastrar produto
                            if (MarcaMarcas())
                            {
                                Funcionalidades.MudarMenu("Cadastro de produto");
                                Console.WriteLine($"Informe o nome do produto");
                            }
                            break;
                        case "2": //* Remover produto
                            Funcionalidades.MudarMenu("");
                            break;
                        case "3": //* Listar produtos
                            Funcionalidades.MudarMenu("");
                            break;

                        //* Gerenciar Marcas
                        case "4": //* Cadastrar marca
                            Funcionalidades.MudarMenu("");
                            break;
                        case "5": //* Remover marca
                            Funcionalidades.MudarMenu("");
                            break;
                        case "6": //* Listar marcas
                            Funcionalidades.MudarMenu("");
                            break;

                        case "9": //* Gerenciar Conta
                            Funcionalidades.MudarMenu("");
                            break;
                        case "0": //* Sair da sua conta
                            Funcionalidades.MudarMenu("");
                            break;
                    }
                }
            }
        }
        //* Métodos
        public void Deslogar(Usuario deslogando)
        {
            Logado = false;
        }
    }
}