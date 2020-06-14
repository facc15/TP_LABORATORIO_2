using System;
using Clases_Abstractas;

namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Persona.ENacionalidad.Argentino.GetType());
        }
    }
}
