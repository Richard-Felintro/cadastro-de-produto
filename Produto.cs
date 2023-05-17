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
        private string Marca;
        private DateTime DataCadastro;
        private Usuario CadastradoPor;
        private List<Produto> ProdutosCatalogados;

        //* MÉTODOS
        //* Cadastrar novo produto
        public void Cadastrar(Produto product)
        {

        }

        //* Deletar produto já existente
        public void Deletar(Produto product)
        {

        }

        //* Listar todos produtos
        public void Listar(List<Produto> produtosCatalogados)
        {

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