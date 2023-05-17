using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_de_produto
{
    public static class Funcionalidades
    {
        ///* Métodos
        public static void MudarMenu(string subtitulo)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Cadastro de Produtos");
            Console.ResetColor();
            Console.Write($"{subtitulo}");
        }
        public static void ValorInvalido(string subtitulo)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Cadastro de Produtos");
            Console.ResetColor();
            Console.WriteLine($"{subtitulo}");
            Console.Write($"Aperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}