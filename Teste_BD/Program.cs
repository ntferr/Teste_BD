using System;
using Teste_BD.Model;
using Teste_BD.Persistence;

namespace Teste_BD
{
    class Program
    {
        static void Main(string[] args)
        {

            var person = new PersonModel();
            var persis = new PersonPersistence();

            var listas = persis.GetAll();

            foreach (var lista in listas)
            {
                Console.WriteLine("Nome: " + lista.Name +
                    "\nIdade: " + lista.Age + "\nSkills: " + lista.Skills);
            }

        }
    }
}
