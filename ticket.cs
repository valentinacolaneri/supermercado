public class Ticket
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public List<TicketItem> Items { get; set; }
    public decimal Total => Items.Sum(i => i.Subtotal) * 1.21m; // IVA 21%

    public Ticket(int id, List<TicketItem> items)
    {
        Id = id;
        Fecha = DateTime.Now;
        Items = items;
    }

    public void Imprimir()
    {
        Console.WriteLine($"Ticket #{Id} - {Fecha}");
        foreach (var item in Items)
        {
            Console.WriteLine($"{item.NombreProducto} x{item.Cantidad} - ${item.Subtotal:F2}");
        }
        Console.WriteLine($"TOTAL (con IVA): ${Total:F2}");
    }
}
