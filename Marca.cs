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
        private List<Marca> marcasCatalogadas = new List<Marca>();
        //* Construtor
        public void Cadastrar(Marca emCadastro)
        {

        }
        //* Métodos
        public void Listar(List<Marca> marcasCatalogadas)
        {

        }

        public void Deletar(Marca aDeletar)
        {

        }
    }
}