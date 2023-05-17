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
        private string NomeMarca;
        private DateTime DataCadastro;
        private List<Marca> MarcasCatalogadas = new List<Marca>();

        //* CONSTRUTOR
        public Marca(bool marcaMestra)
        {
            if (marcaMestra)
            {
                MarcasCatalogadas.Add(this);
            }
        }

        //* MÉTODOS
        //* Cadastrar novo marca
        public void Cadastrar(Marca brand)
        {

        }

        //* Deletar marca já existente
        public void Deletar(Marca brand)
        {

        }

        //* Listar todos marcas
        public void Listar(List<Marca> produtosCatalogados)
        {

        }

        //* Checar se há marcas cadastradas
        public bool ChecarMarcas()
        {
            MarcasCatalogadas.Any();
            {
                return true;
            }
        }
    }
}