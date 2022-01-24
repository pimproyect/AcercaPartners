using PedidosCoches.Entidades;
using PedidosCoches.Negocio.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PedidosCoches.Controllers
{
    [EnableCors(origins: "http://localhost:8082", headers: "*", methods: "*")]
    public class PedidosController : ApiController
    {
        private readonly IRepositorioPedidos _repositorioPedidos;

        public PedidosController(IRepositorioPedidos repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }
        // GET: api/Pedidos
        public IEnumerable<Pedidos> Get()
        {
            return _repositorioPedidos.ObetenerTodos();
        }

        [Route("api/GetPedido")]
        [HttpGet]
        // GET: api/Pedidos/5
        public Pedidos Get(int pedido)
        {
            return _repositorioPedidos.ObetenerPor(z=>z.Pedido == pedido).FirstOrDefault();
        }

        // POST: api/Pedidos
        public void Post([FromBody] Pedidos value)
        {
            _repositorioPedidos.Agregar(value);
        }

        // PUT: api/Pedidos/5
        public void Put([FromBody] Pedidos value)
        {
            _repositorioPedidos.Editar(value);
        }

        [Route("api/Delete")]
        [HttpPost]
        // DELETE: api/Pedidos/5
        public void Delete(int pedido)
        {
            _repositorioPedidos.Eliminar(_repositorioPedidos.ObetenerPor(z => z.Pedido == pedido).FirstOrDefault());
        }
    }
}
