using ProductoMVVMSQLite.Services;
using ProductoMVVMSQLite.Views;

namespace ProductoMVVMSQLite
{
    public partial class App : Application
    {
        public static HJ_ProductoRepository productoRepository {  get; set; }
        public App()
        {
            InitializeComponent();
            productoRepository = new HJ_ProductoRepository();
            MainPage = new NavigationPage(new ProductoPage());
        }
    }
}