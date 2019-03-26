using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WTCoro_AW.Models;

namespace WTCoro_AW.DAL
{
   public interface IPersonRepository : IDisposable
    {
        IEnumerable<Person> GetPeople();
        Person GetPersonByName( int BusinessEntityID);  //which works but what a ridiculous way to search for somone 
        void InsertPerson(Person person);
        void DeletePerson(int BusinessEntityID);          //this bastard as well
        void UpdatePerson(Person person);
        void Save();
    }
    
}