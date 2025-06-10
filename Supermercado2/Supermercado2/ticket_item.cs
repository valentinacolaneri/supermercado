using System.Collections.Generic;
using System;
using System.Linq;

public class TicketItem
{
    public string NombreProducto { get; set; }
    public decimal PrecioUnitario { get; set; }
    public int Cantidad { get; set; }

    public decimal Subtotal => Cantidad >= 5
        ? PrecioUnitario * Cantidad * 0.85m
        : PrecioUnitario * Cantidad;

    public TicketItem(string nombre, decimal precioUnitario, int cantidad)
    {
        NombreProducto = nombre;
        PrecioUnitario = precioUnitario;
        Cantidad = cantidad;
    }
}
