using Microsoft.AspNetCore.Mvc;
using NetCoreYouTube.Models;
using NetCoreYouTube.Recursos;
using Newtonsoft.Json;
using System.Data;

namespace NetCoreYouTube.Controllers
{
    [ApiController]
    [Route("Producto")]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        [Route("Listar")]
        public dynamic ListarProductos(bool estado)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Estado", "1")
            };
            DataTable tCategoria = DBDatos.Listar("Categoria_Listar", parametros);
            DataTable tProducto = DBDatos.Listar("Producto_Listar");

            string JsonCategoria = JsonConvert.SerializeObject(tCategoria);
            string JsonProducto = JsonConvert.SerializeObject(tProducto);
            return new
            {
                success = true,
                message = "exito",
                result = new
                {
                    categoria = JsonConvert.DeserializeObject<List<Categoria>>(JsonCategoria),
                    producto = JsonConvert.DeserializeObject<List<Producto>>(JsonProducto)
                }
            };
        }
    }
}
