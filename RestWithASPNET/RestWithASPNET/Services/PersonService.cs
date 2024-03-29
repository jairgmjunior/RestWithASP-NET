﻿using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;
using RestWithASPNET.Repository.Implementation;
using RestWithASPNET.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            try
            {
                _repository.Create(person);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public void Delete(long id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Update(Person person)
        {
            
            try
            {
                _repository.Update(person);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

    }
}
