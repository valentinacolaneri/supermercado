public class Carrito
{
    private List<ItemCarrito> items = new List<ItemCarrito>();

    public void AgregarItem(Producto producto, int cantidad)
    {
        var existente = items.FirstOrDefault(i => i.Producto.Codigo == producto.Codigo);
        if (existente != null)
            existente.Cantidad += cantidad;
        else
            items.Add(new ItemCarrito(producto, cantidad));
    }

    public void EliminarItem(int codigoProducto)
    {
        items.RemoveAll(i => i.Producto.Codigo == codigoProducto);
    }

    public void VerContenido()
    {
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Producto.Nombre} x{item.Cantidad} - Subtotal: ${item.Subtotal():F2}");
        }
    }

    public decimal CalcularTotal()
    {
        return items.Sum(i => i.Subtotal()) * 1.21m;
    }

    public List<TicketItem> GenerarTicketItems()
    {
        return items.Select(i => new TicketItem(i.Producto.Nombre, i.Producto.PrecioActual, i.Cantidad)).ToList();
    }

    public void Vaciar() => items.Clear();
}
