using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Models.Base;
using RestWithASPNET.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySqlContext _context;
        private readonly DbSet<T> dataset;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T entity)
        {
            try
            {
                dataset.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (result != null) dataset.Remove(result);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exist(long? id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T entity)
        {
            if (!Exist(entity.Id)) return null;

            var result = dataset.SingleOrDefault(p => p.Id.Equals(entity.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }
    }
}
