using System.Collections.Generic;
using System;
using System.Linq;

public class Tienda
{
    public List<Producto> Productos { get; set; } = new List<Producto>();
    public List<Categoria> Categorias { get; set; } = new List<Categoria>();
    public List<Ticket> Historial { get; set; } = new List<Ticket>();
    private int ticketCounter = 1;

    public void FinalizarCompra(Carrito carrito)
    {
        var items = carrito.GenerarTicketItems();

        
        foreach (var item in items)
        {
            var producto = Productos.First(p => p.Nombre == item.NombreProducto);
            producto.Stock -= item.Cantidad;
        }

        var ticket = new Ticket(ticketCounter++, items);
        Historial.Add(ticket);
        carrito.Vaciar();

        ticket.Imprimir();
    }

    public void VerHistorial()
    {
        foreach (var ticket in Historial)
        {
            Console.WriteLine($"Ticket ID: {ticket.Id} - Fecha: {ticket.Fecha}");
        }
    }

    public void VerTicketPorId(int id)
    {
        var ticket = Historial.FirstOrDefault(t => t.Id == id);
        if (ticket != null)
            ticket.Imprimir();
        else
            Console.WriteLine("Ticket no encontrado.");
    }
}
