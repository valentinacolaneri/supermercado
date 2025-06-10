using System.Collections.Generic;
using System;
using System.Linq;

public class ItemCarrito
{
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }

    public ItemCarrito(Producto producto, int cantidad)
    {
        Producto = producto;
        Cantidad = cantidad;
    }

    public decimal Subtotal()
    {
        decimal precioUnitario = Producto.PrecioActual;
        decimal subtotal = precioUnitario * Cantidad;

        if (Cantidad >= 5)
            subtotal *= 0.85m; 

        return subtotal;
    }
}
