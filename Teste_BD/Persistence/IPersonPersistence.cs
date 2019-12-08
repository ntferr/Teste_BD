using System;
using System.Collections.Generic;
using Teste_BD.Model;

namespace Teste_BD.Persistence
{
    public interface IPersonPersistence
    {
        public PersonModel GetById(int id);
        public IEnumerable<PersonModel> GetAll();
        public void InsertPerson(PersonModel person);
        public void DeletePerson(int id);
    }
}