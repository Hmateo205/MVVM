using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class HJ_DetailProductoViewModel
    {
        private int _idProducto = 0;
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }
        private HJ_Producto ProductoEncontrado { get; set; }

        public HJ_DetailProductoViewModel() { }

        public HJ_DetailProductoViewModel (HJ_Producto producto)
        {
            _idProducto = producto.IdProducto;
            ProductoEncontrado = producto;
            Nombre = producto.Nombre;
            Descripcion = producto.Descripcion;
            Cantidad = producto.Cantidad.ToString();
        }

        public HJ_DetailProductoViewModel(int IdProducto)
        {
            _idProducto = IdProducto;
            ProductoEncontrado = App.productoRepository.Get(_idProducto);
            Nombre = ProductoEncontrado.Nombre;
            Descripcion = ProductoEncontrado.Descripcion;
            Cantidad = ProductoEncontrado.Cantidad.ToString();

        }

        public ICommand GuardarProducto =>
            new Command(async () =>
            {
                if (_idProducto == 0)
                {
                    HJ_Producto producto = new HJ_Producto
                    {
                        Nombre = Nombre,
                        Descripcion = Descripcion,
                        Cantidad = Int32.Parse(Cantidad),
                    };
                    App.productoRepository.Add(producto);

                }
                else
                {
                    ProductoEncontrado.Nombre = Nombre;
                    ProductoEncontrado.Cantidad = Int32.Parse(Cantidad);
                    ProductoEncontrado.Descripcion = Descripcion;

                    App.productoRepository.Update(ProductoEncontrado);

                }
                HJ_Util.ListaProductos.Clear();
                App.productoRepository.GetAll().ForEach(HJ_Util.ListaProductos.Add);
                await App.Current.MainPage.Navigation.PopAsync();
            });

    }
}
