﻿using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using ProductoMVVMSQLite.Views;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class HJ_ProductoViewModel
    {
        public ObservableCollection<HJ_Producto> ListaProductos { get; set; }

        public HJ_ProductoViewModel() {

            HJ_Util.ListaProductos = new ObservableCollection<HJ_Producto>( App.productoRepository.GetAll());

            ListaProductos = HJ_Util.ListaProductos;


        }

        public ICommand CrearProducto =>
            new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new NuevoProductoPage());
            });

        public ICommand EliminarProducto => new Command<HJ_Producto>(async (producto) =>
        {
           
                App.productoRepository.Delete(producto);
                HJ_Util.ListaProductos.Remove(producto);
            
        });
        public ICommand EditarProducto => new Command<HJ_Producto>(async (producto) =>
        {
            await App.Current.MainPage.Navigation.PushAsync(new DetailProductoPage(producto.IdProducto)); //ir a pagina editar
        });

    }
}
