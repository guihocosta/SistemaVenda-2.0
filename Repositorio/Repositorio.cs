using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public abstract class Repositorio<TEntidade> : DbContext, IRepositorio<TEntidade> where
        TEntidade : EntityBase, new()
    {
        protected DbContext Db;
        protected DbSet<TEntidade> DbSetContext;

        public Repositorio(DbContext dbContext)
        {
            Db = dbContext;
            DbSetContext = Db.Set<TEntidade>();
        }
        public void Create(TEntidade entity)
        {
            if (entity.Codigo == null)
            {
                DbSetContext.Add(entity);
            }
            else
            {
                Db.Entry(entity).State = EntityState.Modified;
            }

            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = new TEntidade {Codigo = id};
            DbSetContext.Attach(entity);
            DbSetContext.Remove(entity);
            Db.SaveChanges();

        }

        public virtual TEntidade Read(int id)
        {
            return DbSetContext.Where(x => x.Codigo == id).FirstOrDefault();
        }

        public virtual IEnumerable<TEntidade> Read()
        {
            return DbSetContext.AsNoTracking().ToList();
        }
    }
}
