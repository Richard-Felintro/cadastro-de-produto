using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_de_produto
{
    public class Produto
    {
        //* Atributos
        private int Codigo;
        private string NomeProduto;
        private float Preco;
        private Marca Marca;
        private DateTime DataCadastro;
        private Usuario CadastradoPor;
        private string CadastradoPorNome;
        private List<Produto> ProdutosCatalogados;

        //* Construtor

        public Produto()
        {
            Cadastrar(this);
        }
        public Produto(bool main)
        {
        }

        //* MÉTODOS
        //* Cadastrar novo produto
        public void Cadastrar(Produto product)
        {
            //* Variáveis declaradas
            int codigoAttempt = 0;
            bool codigoValido = false;
            bool precoValido = false;
            bool marcaValida = false;
            string prodPrecoInput;
            float precoInput = 0;
            string prodMarcaInput;
            var marcaAttempt = Marca;

            //* Usuário informa o nome do produto
            Funcionalidades.MudarMenu("Cadastro de produto");
            Console.WriteLine($"Determine o nome do produto");
            string prodNomeInput = Console.ReadLine();

            //* Pergunta e checa se o preço informado é válido
            while (precoValido == false)
            {
                Funcionalidades.MudarMenu("Cadastro de produto");
                Console.WriteLine($"Determine o preço do produto");
                prodPrecoInput = Console.ReadLine();
                precoValido = float.TryParse(prodPrecoInput, out _);
                if (precoValido)
                {
                    precoInput = float.Parse(prodPrecoInput);
                }
                else
                {
                    Funcionalidades.ValorInvalido("Um preço deve ser um número natural ou decimal.");
                }
            }

            //* Pergunta e checa se a marca informada é válida
            while (marcaValida == false)
            {
                Funcionalidades.MudarMenu("Cadastro de produto");
                Console.WriteLine($"Informe o nome da marca do produto");
                prodMarcaInput = Console.ReadLine();
                marcaAttempt = Global.marcaGlobal[0].ProcurarMarca(prodMarcaInput);
                if (marcaAttempt == null)
                {
                    Funcionalidades.ValorInvalido("Marca não encontrada");
                }
                else
                {
                    marcaValida = true;
                }
            }

            //* Gerando código aleatório
            Random codeRandom = new Random();
            while (codigoValido == false)
            {
                codigoAttempt = codeRandom.Next(100000000, 999999999);
                if (ProdutosCatalogados.Exists(x => x.Codigo == codigoAttempt))
                {
                    codigoValido = false;
                }
                else { codigoValido = true; }
            }

            //* Utiliza os valores informados
            this.Codigo = codigoAttempt;
            this.NomeProduto = prodNomeInput;
            this.Preco = precoInput;
            this.Marca = marcaAttempt;
            this.CadastradoPor = Login.checarUser();
            this.DataCadastro = DateTime.Now;
        }

        // ******************************** //
        // * Deletar produto já existente * //
        // ******************************** //
        public static bool Deletar()
        {
            Funcionalidades.MudarMenu("Informe o nome ou código do produto que deseja remover:");
            string deletarInput = Console.ReadLine();

            //* Se um código foi inserido
            if (int.TryParse(deletarInput, out _) && deletarInput.Length == 9)
            {
                var produtoDeletando = Global.produtoGlobal[0].ProdutosCatalogados.Find(x => x.Codigo == int.Parse(deletarInput));
                if (produtoDeletando == null)
                {
                    return false;
                }
                else
                {
                    Global.produtoGlobal[0].ProdutosCatalogados.Remove(produtoDeletando);
                    return true;
                }
            }

            //* Se um nome foi inserido
            else
            {
                var produtoDeletando = Global.produtoGlobal[0].ProdutosCatalogados.Find(x => x.NomeProduto == deletarInput);
                if (produtoDeletando == null)
                {
                    return false;
                }
                else
                {
                    Global.produtoGlobal[0].ProdutosCatalogados.Remove(produtoDeletando);
                    return true;
                }
            }
        }

        //* Listar todos produtos
        public void Listar()
        {
            if (ProdutosCatalogados.Any())
            {
                Funcionalidades.MudarMenu("Lista de produtos catalogados:");
                foreach (var p in ProdutosCatalogados)
                {
                    Console.WriteLine($"Produto : {p.NomeProduto} | {p.Preco:c2} | Marca : {p.Marca.NomeMarca}");
                    Console.WriteLine($"Cadastrado em: {p.DataCadastro} por {p.CadastradoPor.Nome}\n");
                }
            }
            else
            {
                Funcionalidades.ValorInvalido("Nenhum produto foi catalogado até o momento.");
            }
        }

        //* Checar se há produtos cadastrados
        public bool ChecarProdutos()
        {
            if (ProdutosCatalogados.Any())
            {
                return true;
            }
            return false;
        }
    }
}