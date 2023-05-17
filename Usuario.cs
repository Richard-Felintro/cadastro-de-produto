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
        private static List<Usuario> ListaDeUsuarios = new List<Usuario>();

        //* Metodos
        public Usuario(bool Cadastro)
        {
            if (Cadastro)
            {
                Cadastrar(this);
                ListaDeUsuarios.Add(this);
            }
        }
        public void Cadastrar(Usuario user_)
        {
            //* Variáveis
            bool emailValido = false;
            bool senhaValida = false;
            bool codigoValido = false;
            string emailInput = "lorem";
            string senhaInput = "ipsum";
            int codigoAttempt = 0;

            //* Usuário informa seu nome
            Login.MudarMenu("Informe o nome do usuário: ");
            string nomeInput = Console.ReadLine();

            //* Usuário informa seu email
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
                            emailValido = false;
                            return;
                        }
                    }
                }
            }

            //* Usuário informa sua senha
            while (senhaValida != true)
            {
                Login.MudarMenu("Sua senha deve conter 8 ou mais caracteres e ao menos um caractere não numeral.\n");
                Console.Write($"Informe a senha do usuário: ");
                senhaValida = true;
                senhaInput = Console.ReadLine();
                if (senhaInput.Length < 8) { senhaValida = false; }
                if (int.TryParse(senhaInput, out _)) { senhaValida = false; }
            }
            //* CODIGO E DATA (DETERMINADOS AUTOMATICAMENTE)
            while (codigoValido == false)
            {
                codigoValido = true;
                Random codeRandom = new Random();
                codigoAttempt = codeRandom.Next(100000000, 999999999);
                if (Usuario.ListaDeUsuarios.Exists(x => x.Codigo == codigoAttempt))
                {
                    codigoValido = false;
                }
            }

            //* Aplicando os dados obtidos
            user_.Nome = nomeInput;
            user_.Email = emailInput;
            user_.Senha = senhaInput;
            user_.DataCadastro = DateTime.Now;
            user_.Codigo = codigoAttempt;

            //* Tela de sucesso
            Login.MudarMenu("Usuário cadastrado com sucesso!\n");
            Console.Write($"Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        //* TELA DE LOGIN
        public static bool Logar(string emailInput, string senhaInput)
        {
            Usuario aLogar = new Usuario(false);
            aLogar.Email = emailInput;
            aLogar.Senha = senhaInput;

            //* Checando se o email foi cadastrado
            var emailValido = Usuario.ListaDeUsuarios.Find(x => x.Email == aLogar.Email);
            if (emailValido != null)
            {
                if (emailValido.Senha == aLogar.Senha) //* Checando se a senha coincide com o email
                {
                    return true;
                }
            }
            return false;
        }
        public void Deletar(Usuario user_)
        {
            ListaDeUsuarios.Remove(user_);
        }
    }
}
