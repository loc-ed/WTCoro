using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WTCoro_AW.Models;
using System.Data;

namespace WTCoro_AW.DAL
{
    public class PersonRepository : IPersonRepository
    {
        private AdventureWorks2017Entities _adventure;
        public PersonRepository(AdventureWorks2017Entities aw_context)
        {
            this._adventure = aw_context;
        }
        public IEnumerable<Person> GetPeople()
        {
            return _adventure.People.ToList();
        }
        public Person GetPersonByName(int BusinessEntityID)
        {
          return _adventure.People.Find(BusinessEntityID);              
        }
        public void InsertPerson(Person person)
        {
            _adventure.People.Add(person);
        }
        public void DeletePerson(int BusinessEntityID)            
        {
            Person person = _adventure.People.Find(BusinessEntityID);   
            _adventure.People.Remove(person);
        }
        public void UpdatePerson(Person person)
        {
            _adventure.Entry(person).State = System.Data.Entity.EntityState.Modified;
        }
        public void Save()
        {
            _adventure.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _adventure.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    
}