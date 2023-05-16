using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_de_produto
{
    public class Usuario
    {
        //* Atributos
        private int Codigo;
        private string Nome;
        private string Email;
        private string Senha;
        private DateTime DataCadastro;
        public List<Usuario> ListaDeUsuarios = new List<Usuario>();

        //* Metodos
        public Usuario()
        {
            Cadastrar(this);
            ListaDeUsuarios.Add(this);
        }
        public void Cadastrar(Usuario user_)
        {
            //* Variáveis
            bool emailValido = false;
            bool senhaValida = false;
            string emailInput = "lorem";
            string senhaInput = "ipsum";

            //* NOME DO USUÁRIO
            Login.MudarMenu("Informe o nome do usuário: ");
            string nomeInput = Console.ReadLine();

            //* EMAIL DO USUÁRIO
            while (emailValido == false)
            {
                Login.MudarMenu("Informe o email do usuário: ");
                emailInput = Console.ReadLine();
                emailValido = true;
                if (ListaDeUsuarios.Any())
                {
                    foreach (var user in ListaDeUsuarios)
                    {
                        if (emailInput == user.Email)
                        {
                            Login.ValorInvalido("Este email já está em uso");
                            Console.WriteLine($"Aperte ENTER para continuar");
                            Console.ReadLine();
                            emailValido = false;
                            return;
                        }
                    }
                }
            }

            //* SENHA DO USUÁRIO
            while (senhaValida != true)
            {
                Login.MudarMenu("Sua senha deve conter 8 ou mais caracteres e ao menos um caractere não numeral.\n");
                Console.Write($"Informe a senha do usuário: ");
                senhaValida = true;
                senhaInput = Console.ReadLine();
                if (senhaInput.Length < 8) { senhaValida = false; }
                if (int.TryParse(senhaInput, out _)) { senhaValida = false; }
            }

            //* Utilizando os dados obtidos
            user_.Nome = nomeInput;
            user_.Email = emailInput;
            user_.Senha = senhaInput;
            user_.DataCadastro = DateTime.Now;
            user_.Codigo = ListaDeUsuarios.Count;
        }
        public void Deletar(Usuario user_)
        {
            ListaDeUsuarios.Remove(user_);
        }

    }
}