using PedidosCoches.Data;
using PedidosCoches.Entidades;
using PedidosCoches.Negocio.Facades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PedidosCoches.Negocio.Implements
{
    public class RepositorioPedidos : RepositorioGenerico<CochesModel, Pedidos>, IRepositorioPedidos
    {
        
    }
}