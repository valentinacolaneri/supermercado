using System.Collections.Generic;
using System;
using System.Linq;

public class Producto
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public decimal PrecioActual { get; set; }
    public int Stock { get; set; }
    public Categoria Categoria { get; set; }

    public Producto(int codigo, string nombre, decimal precio, int stock, Categoria categoria)
    {
        Codigo = codigo;
        Nombre = nombre;
        PrecioActual = precio;
        Stock = stock;
        Categoria = categoria;
    }
}
