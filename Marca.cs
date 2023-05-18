using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_de_produto
{
    public class Marca
    {
        //* Atributos
        private int Codigo;
        public string NomeMarca;
        private DateTime DataCadastro;
        public static Marca main = new Marca(true);
        public List<Marca> MarcasCatalogadas = new List<Marca>();

        //* CONSTRUTOR
        public Marca()
        {
            {
                Cadastrar(this);
                MarcasCatalogadas.Add(this);
            }
        }

        public Marca(bool marcaMestra)
        {
            this.NomeMarca = "Marca Mestra";
            this.Codigo = 0;
            MarcasCatalogadas.Add(this);
        }

        //* MÉTODOS
        //* Cadastrar novo marca
        public void Cadastrar(Marca brand)
        {
            bool codigoValido = false;
            int codigoAttempt = 0;
            Funcionalidades.MudarMenu("Determine o nome da marca: ");
            string nomeInput = Console.ReadLine();

            //* Gerando código aleatório
            Random codeRandom = new Random();
            while (codigoValido == false)
            {
                codigoAttempt = codeRandom.Next(100000000, 999999999);
                if (MarcasCatalogadas.Exists(x => x.Codigo == codigoAttempt))
                {
                    codigoValido = false;
                }
                else { codigoValido = true; }
            }
            //* Utiliza os valores informados
            brand.NomeMarca = nomeInput;
            brand.Codigo = codigoAttempt;
            this.DataCadastro = DateTime.Now;
        }

        //* Deletar marca já existente
        public static bool Deletar()
        {
            Funcionalidades.MudarMenu("Informe o nome ou código da marca que deseja remover:");
            string deletarInput = Console.ReadLine();

            //* Se um código foi inserido
            if (int.TryParse(deletarInput, out _) && deletarInput.Length == 9)
            {
                var produtoDeletando = Global.marcaGlobal[0].MarcasCatalogadas.Find(x => x.Codigo == int.Parse(deletarInput));
                if (produtoDeletando == null)
                {
                    return false;
                }
                else
                {
                    Global.marcaGlobal[0].MarcasCatalogadas.Remove(produtoDeletando);
                    return true;
                }
            }

            //* Se um nome foi inserido
            else
            {
                var produtoDeletando = Global.marcaGlobal[0].MarcasCatalogadas.Find(x => x.NomeMarca == deletarInput);
                if (produtoDeletando == null)
                {
                    return false;
                }
                else
                {
                    Global.marcaGlobal[0].MarcasCatalogadas.Remove(produtoDeletando);
                    return true;
                }
            }
        }

        //* Listar todos marcas
        public void Listar()
        {
            if (MarcasCatalogadas.Any())
            {
                Funcionalidades.MudarMenu("Lista de produtos catalogados:");
                for (var i = 1; i < MarcasCatalogadas.Count(); i++)
                {
                    Console.WriteLine($"Marca : {MarcasCatalogadas[i].NomeMarca} | Codigo : {MarcasCatalogadas[i].Codigo}");
                    Console.WriteLine($"Cadastrado em: {MarcasCatalogadas[i].DataCadastro}\n");
                }
                Console.Write($"Aperte ENTER para continuar...");
                Console.ReadLine();
            }
            else
            {
                Funcionalidades.ValorInvalido("Nenhuma marca foi catalogada até o momento.");
            }
        }

        //* Procura uma marca por nome
        public Marca ProcurarMarca(string nomeProcurado)
        {
            var marcaAchada = main.MarcasCatalogadas.Find(x => x.NomeMarca.ToLower() == nomeProcurado.ToLower());
            return marcaAchada;
        }

        //* Checar se há marcas cadastradas
        public bool ExistemMarcas()
        {
            MarcasCatalogadas.Any();
            {
                return true;
            }
        }
    }
}