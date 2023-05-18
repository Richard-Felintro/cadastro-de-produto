using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_de_produto
{
    public class Login
    {
        //* Atributos
        private static Usuario Logado = null;

        //* Construtor
        public Login()
        {
            bool loopInfinito = true;
            while (loopInfinito)
            {
                while (Logado == null)
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
                            if (Usuario.Logar(emailInput, senhaInput) != null)
                            {
                                Funcionalidades.MudarMenu("Usuário logado com sucesso!\n");
                                Logado = Usuario.Logar(emailInput, senhaInput);
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
                while (Logado != null)
                {
                    // *************************************** //
                    // *   TELA PRINCIPAL | USUÁRIO LOGADO   * //
                    // *************************************** //
                    Funcionalidades.MudarMenu("Menu principal\n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($@"Gerenciar Produtos");
                    Console.ResetColor();
                    Console.WriteLine($"[1] Cadastrar Produtos");
                    Console.WriteLine($"[2] Remover Produtos");
                    Console.WriteLine($"[3] Listar Produtos");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Gerenciar Marcas");
                    Console.ResetColor();
                    Console.WriteLine($"[4] Cadastrar Marcas");
                    Console.WriteLine($"[5] Remover Marcas");
                    Console.WriteLine($"[6] Listar Marcas");

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Gerenciar Conta");
                    Console.ResetColor();
                    Console.WriteLine($"[9] Remover sua conta");
                    Console.WriteLine($"[0] Sair de sua conta");
                    string mainMenuInput = Console.ReadLine();
                    switch (mainMenuInput)
                    {
                        //* Gerenciar produtos
                        case "1": //* Cadastrar produto
                            if (Global.marcaGlobal[0].ExistemMarcas())
                            {
                                Produto product = new Produto();
                            }
                            else
                            {
                                Funcionalidades.ValorInvalido("Um produto não pode ser cadastrado até uma marca ser cadastrada.");
                            }
                            break;
                        case "2": //* Remover produto
                            Produto.Deletar();
                            break;
                        case "3": //* Listar produtos
                            Global.produtoGlobal[0].Listar();
                            break;

                        //* Gerenciar Marcas
                        case "4": //* Cadastrar marca
                            Marca brand = new Marca();
                            break;
                        case "5": //* Remover marca
                            Marca.Deletar();
                            break;
                        case "6": //* Listar marcas
                            Global.marcaGlobal[0].Listar();
                            break;

                        case "9": //* Remover Conta
                            Funcionalidades.MudarMenu("Tem certeza que deseja remover sua conta?\n");
                            Console.WriteLine($"[1] Sim, desejo remover minha conta permanentemente");
                            Console.WriteLine($"[2] Não, ainda desejo usufruir dos imáculos serviços de RICARDÃO INC");
                            string removerInput = Console.ReadLine();
                            switch (removerInput)
                            {
                                case "1":
                                    Usuario.Deletar(Logado);
                                    Deslogar();
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "0":
                            Deslogar();
                            break;
                    }
                }
            }
        }
        //* Métodos
        public void Deslogar()
        {
            Logado = null;
        }

        public static Usuario checarUser()
        {
            return (Logado);
        }
    }
}