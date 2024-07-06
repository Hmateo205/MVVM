using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class DetailProductoPage : ContentPage
{
	public DetailProductoPage()
	{
		InitializeComponent();
		BindingContext = new HJ_DetailProductoViewModel();
	}
	public DetailProductoPage(int IdProducto) 
	{
        InitializeComponent();
        HJ_Producto producto = App.productoRepository.Get(IdProducto);
		BindingContext = new HJ_DetailProductoViewModel(producto);
    }
}