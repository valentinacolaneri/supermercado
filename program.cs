class Program
{
    static void Main(string[] args)
    {
        Tienda tienda = new Tienda();
        Carrito carrito = new Carrito();

        // Datos de prueba
        var cat1 = new Categoria("Bebidas", "Productos líquidos para beber");
        var cat2 = new Categoria("Lácteos", "Productos derivados de la leche");
        tienda.Categorias.AddRange(new[] { cat1, cat2 });

        tienda.Productos.Add(new Producto(1, "Coca-Cola", 150, 10, cat1));
        tienda.Productos.Add(new Producto(2, "Agua Mineral", 100, 20, cat1));
        tienda.Productos.Add(new Producto(3, "Leche Entera", 200, 15, cat2));

        while (true)
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Ver categorías disponibles");
            Console.WriteLine("2. Ver productos disponibles");
            Console.WriteLine("3. Ver productos por categoría");
            Console.WriteLine("4. Agregar producto al carrito");
            Console.WriteLine("5. Eliminar producto del carrito");
            Console.WriteLine("6. Ver contenido del carrito");
            Console.WriteLine("7. Ver total a pagar");
            Console.WriteLine("8. Finalizar compra");
            Console.WriteLine("9. Ver historial de compras");
            Console.WriteLine("10. Ver ticket por ID");
            Console.WriteLine("0. Salir");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    foreach (var cat in tienda.Categorias)
                        Console.WriteLine($"- {cat.Nombre}: {cat.Descripcion}");
                    break;

                case "2":
                    foreach (var p in tienda.Productos)
                        Console.WriteLine($"{p.Codigo}. {p.Nombre} - ${p.PrecioActual} - Stock: {p.Stock}");
                    break;

                case "3":
                    Console.Write("Ingrese nombre de categoría: ");
                    string nombreCat = Console.ReadLine();
                    var productosCat = tienda.Productos.Where(p => p.Categoria.Nombre.Equals(nombreCat, StringComparison.OrdinalIgnoreCase));
                    foreach (var p in productosCat)
                        Console.WriteLine($"{p.Codigo}. {p.Nombre} - ${p.PrecioActual} - Stock: {p.Stock}");
                    break;

                case "4":
                    Console.Write("Ingrese código del producto: ");
                    if (!int.TryParse(Console.ReadLine(), out int codigo)) break;
                    var prod = tienda.Productos.FirstOrDefault(p => p.Codigo == codigo);
                    if (prod == null) { Console.WriteLine("Código inválido."); break; }
                    Console.Write("Ingrese cantidad: ");
                    if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
                    {
                        Console.WriteLine("Cantidad inválida.");
                        break;
                    }
                    if (cantidad > prod.Stock)
                    {
                        Console.WriteLine("No hay suficiente stock.");
                        break;
                    }
                    carrito.AgregarItem(prod, cantidad);
                    Console.WriteLine("Producto agregado al carrito.");
                    break;

                case "5":
                    Console.Write("Ingrese código del producto a eliminar: ");
                    if (!int.TryParse(Console.ReadLine(), out int codigoDel)) break;
                    carrito.EliminarItem(codigoDel);
                    Console.WriteLine("Producto eliminado del carrito.");
                    break;

                case "6":
                    carrito.VerContenido();
                    break;

                case "7":
                    Console.WriteLine($"Total a pagar (IVA incluido): ${carrito.CalcularTotal():F2}");
                    break;

                case "8":
                    tienda.FinalizarCompra(carrito);
                    break;

                case "9":
                    tienda.VerHistorial();
                    break;

                case "10":
                    Console.Write("Ingrese ID del ticket: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                        tienda.VerTicketPorId(id);
                    else
                        Console.WriteLine("ID inválido.");
                    break;

                case "0":
                    Console.WriteLine("Gracias por usar el sistema. ¡Hasta luego!");
                    return;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}
