using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoMVVMSQLite.Services
{
    public class ProductoRepository
    {
        SQLiteConnection connection;
        public ProductoRepository() {

            connection = new SQLiteConnection(Util.DataBasePath, Util.Flags);
            connection.CreateTable<HJ_Producto>();
        
        }


        public List<HJ_Producto> GetAll()
        {
            List<HJ_Producto> ListaProductos = new List<HJ_Producto>();
            try{
                ListaProductos = connection.Table<HJ_Producto>().ToList();  
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ListaProductos;
        }

        public HJ_Producto Get(int IdProducto)
        {
            HJ_Producto producto = null;
            try{

                producto = connection.Table<HJ_Producto>()
                    .FirstOrDefault(x=>x.IdProducto==IdProducto);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return producto;

        }

        public void Add(HJ_Producto producto)
        {
            try
            {
                connection.Insert(producto);
            }catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(HJ_Producto producto)
        {
            try
            {
                if (producto.IdProducto != 0)
                {
                    connection.Update(producto);
                }
            }catch(Exception ex) { 
                Console.WriteLine(ex.Message); 
            }
        }

        public void Delete(HJ_Producto producto)
        {
            try{
                if (producto.IdProducto != 0)
                {
                    connection.Delete(producto);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
