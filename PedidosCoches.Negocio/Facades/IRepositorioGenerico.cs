using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PedidosCoches.Negocio.Facades
{
    public interface IRepositorioGenerico<TEntity>
    {
        IEnumerable<TEntity> ObetenerTodos();

        IEnumerable<TEntity> ObetenerPor(Expression<Func<TEntity, bool>> predicado);

        bool Agregar(TEntity entity);

        bool Editar(TEntity entity);

        bool Eliminar(TEntity entity);

        void Guardar();
    }
}
