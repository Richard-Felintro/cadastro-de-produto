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
        private static List<Marca> MarcasCatalogadas = new List<Marca>();

        //* CONSTRUTOR
        public Marca()
        {
            {
                Cadastrar(this);
            }
        }

        //* MÉTODOS

        //* Cadastrar novo marca
        static public void Cadastrar(Marca brand)
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
            brand.DataCadastro = DateTime.Now;

            Funcionalidades.MudarMenu("Marca criada com sucesso!\n");
            Console.WriteLine($"Nome : {brand.NomeMarca}");
            Console.WriteLine($"Codigo : {brand.Codigo}");
            Console.WriteLine($"Cadastrado em : {brand.DataCadastro}");
            Console.Write($"\nAperte ENTER para continuar...");
            MarcasCatalogadas.Add(brand);
            Console.ReadLine();
        }

        //* Deleta marca já existente
        public static bool Deletar()
        {
            Funcionalidades.MudarMenu("Informe o nome ou código da marca que deseja remover:");
            string deletarInput = Console.ReadLine();

            //* Se um código foi inserido
            if (int.TryParse(deletarInput, out _) && deletarInput.Length == 9)
            {
                var produtoDeletando = MarcasCatalogadas.Find(x => x.Codigo == int.Parse(deletarInput));
                if (produtoDeletando == null)
                {
                    return false;
                }
                else
                {
                    MarcasCatalogadas.Remove(produtoDeletando);
                    return true;
                }
            }

            //* Se um nome foi inserido
            else
            {
                var produtoDeletando = MarcasCatalogadas.Find(x => x.NomeMarca == deletarInput);
                if (produtoDeletando == null)
                {
                    return false;
                }
                else
                {
                    MarcasCatalogadas.Remove(produtoDeletando);
                    return true;
                }
            }
        }

        //* Listar todos marcas
        public static void Listar()
        {
            if (MarcasCatalogadas.Any())
            {
                Funcionalidades.MudarMenu("Lista de marcas catalogadas:\n\n");
                foreach (var m in MarcasCatalogadas)
                {
                    Console.WriteLine($"Marca : {m.NomeMarca} | Codigo : {m.Codigo}");
                    Console.WriteLine($"Cadastrado em: {m.DataCadastro}\n");
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
            foreach (var item in MarcasCatalogadas)
            {
                if (item.NomeMarca.ToLower() == nomeProcurado.ToLower())
                {
                    Console.WriteLine($"encontrou marca");
                    
                    return item;
                }
                Console.WriteLine($"entrou no loop");
            }
            Console.ReadLine();
            return null;
        }

        //* Checar se há marcas cadastradas
        public static bool ExistemMarcas()
        {
            if (MarcasCatalogadas.Any())
            {
                return true;
            }
            return false;
        }
    }
}