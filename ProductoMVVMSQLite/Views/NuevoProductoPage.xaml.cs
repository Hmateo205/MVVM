using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class NuevoProductoPage : ContentPage
{
    public NuevoProductoPage()
    {
        InitializeComponent();
        BindingContext = new HJ_NuevoProductoViewModel();
    }

    public NuevoProductoPage(int IdProducto)
    {
		InitializeComponent();
        HJ_Producto producto = App.productoRepository.Get(IdProducto);
        BindingContext = new HJ_NuevoProductoViewModel(producto);
    }
}