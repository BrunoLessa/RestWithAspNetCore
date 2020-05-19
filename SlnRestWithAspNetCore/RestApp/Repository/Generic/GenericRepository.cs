using Microsoft.EntityFrameworkCore;
using RestApp.Model.Base;
using RestApp.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Repository.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MySqlContext _context;
        private DbSet<TEntity> dataset;
        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataset = _context.Set<TEntity>();
        }
        public TEntity Create(TEntity objeto)
        {
            try
            {
                dataset.Add(objeto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objeto;
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id == id);

            if (result == null)
                return;

            try
            {
                dataset.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TEntity> FindAll()
        {
            return dataset.ToList();
        }

        public TEntity FindById(long id)
        {
            return dataset.FirstOrDefault(x => x.Id == id);
        }

        public TEntity Update(TEntity objeto)
        {
            var result = dataset.SingleOrDefault(p => p.Id == objeto.Id);

            if (result == null)
                return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(objeto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
    }
}
