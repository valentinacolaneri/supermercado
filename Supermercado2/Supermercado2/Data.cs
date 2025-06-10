using System.Collections.Generic;
using System;
using System.Linq;

namespace supermercado
{
    public static class Data
    {
        public static void CargarDatos(Tienda tienda)
        {
            // Crear categorías
            var categoriaElectronica = new Categoria("Electrónica", "Productos electrónicos y dispositivos");
            var categoriaRopa = new Categoria("Ropa", "Prendas de vestir");
            var categoriaHogar = new Categoria("Hogar", "Artículos para el hogar");
            var categoriaAlimentos = new Categoria("Alimentos", "Productos alimenticios");

            // Agregar categorías a la tienda
            tienda.Categorias.AddRange(new List<Categoria>)
            {
                categoriaElectronica,
            categoriaRopa,
            categoriaHogar,
            categoriaAlimentos
        });

            // Crear y agregar productos
            tienda.Productos.AddRange(new List<Producto>
        {
            new Producto(1, "Smartphone", 500m, 20, categoriaElectronica),
            new Producto(2, "Laptop", 1200m, 15, categoriaElectronica),
            new Producto(3, "Auriculares", 80m, 30, categoriaElectronica),
            new Producto(4, "Camiseta", 25m, 50, categoriaRopa),
            new Producto(5, "Pantalón", 45m, 40, categoriaRopa),
            new Producto(6, "Zapatos", 60m, 25, categoriaRopa),
            new Producto(7, "Sofá", 350m, 10, categoriaHogar),
            new Producto(8, "Mesa", 200m, 12, categoriaHogar),
            new Producto(9, "Silla", 50m, 30, categoriaHogar),
            new Producto(10, "Leche", 2m, 100, categoriaAlimentos),
            new Producto(11, "Pan", 1.5m, 80, categoriaAlimentos),
            new Producto(12, "Fruta", 3m, 60, categoriaAlimentos)
        });
        }
    }
}