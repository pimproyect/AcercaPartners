using PedidosCoches.Negocio.Facades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PedidosCoches.Negocio.Implements
{
    public class RepositorioGenerico<TContext, TEntity> : IRepositorioGenerico<TEntity>
        where TContext : DbContext, new() where TEntity : class
    {
        private TContext contexto = new TContext();

        public RepositorioGenerico()
        {
            this.contexto.Configuration.ProxyCreationEnabled = false;
        }

        public TContext Contexto
        {
            get { return contexto; }
            set { contexto = value; }
        }
        public virtual bool Agregar(TEntity entity)
        {
            try
            {
                this.contexto.Set<TEntity>().Add(entity);
                this.Guardar();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public virtual bool Editar(TEntity entity)
        {
            try
            {
                this.contexto.Entry<TEntity>(entity).State = EntityState.Modified;
                this.Guardar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Eliminar(TEntity entity)
        {
            try
            {
                this.contexto.Set<TEntity>().Remove(entity);
                this.Guardar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual void Guardar()
        {
            this.contexto.SaveChanges();
        }

        public virtual IEnumerable<TEntity> ObetenerPor(Expression<Func<TEntity, bool>> predicado)
        {
            return this.contexto.Set<TEntity>().Where(predicado);
        }

        public virtual IEnumerable<TEntity> ObetenerTodos()
        {
            return this.contexto.Set<TEntity>();
        }
    }
}
