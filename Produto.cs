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
        private DateTime DataCadastro;
        private string Marca;
        private Usuario CadastradoPor;
        private List<Produto> ListaDeProdutos;
    }
}