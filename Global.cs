using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_de_produto
{
    public static class Global
    {
        public static List<Marca> marcaGlobal = new List<Marca>();
        public static List<Produto> produtoGlobal = new List<Produto>();

        static Global()
        {
            Marca marcaMestra = new Marca(true);
            marcaGlobal.Add(marcaMestra);
            Produto produtoMestre = new Produto(true);
            produtoGlobal.Add(produtoMestre);
        }
    }
}