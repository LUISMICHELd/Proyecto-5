
using Spectre.Console;
using SistemaDelivery.Models;
using SistemaDelivery.Services;

class Program
{
    public static bool running = true;

    public static string[] choices =
    {
        "1. Mostrar deliveries",
        "2. Eliminar un delivery",
        "3. Agregar un delivery",
        "4. Salir"
    };

    public static DeliveryService deliveryService = new();

    public static void Main()
    {
        while (running)
        {
            var selections = new SelectionPrompt<string>()
                .Title("[green]Indica la acción a realizar:[/]")
                .HighlightStyle("DarkGoldenrod")
                .AddChoices(choices);

            var option = AnsiConsole.Prompt(selections);

            List<Delivery> deliveries = deliveryService.FindAll();

            switch (option)
            {
                case "1. Mostrar deliveries":

                    AnsiConsole.Clear();

                    var table = new Table();

                    table.AddColumn("Id");
                    table.AddColumn("Cliente");
                    table.AddColumn("Dirección");
                    table.AddColumn("Pedido");

                    foreach (Delivery delivery in deliveries)
                    {
                        table.AddRow(
                            delivery.Id.ToString(),
                            delivery.Cliente,
                            delivery.Direccion,
                            delivery.Pedido
                        );
                    }

                    AnsiConsole.Write(table);

                    break;

                case "2. Eliminar un delivery":

                    AnsiConsole.Clear();

                    if (deliveries.Count == 0)
                    {
                        AnsiConsole.MarkupLine(
                            "[yellow]No hay deliveries registrados.[/]"
                        );
                        break;
                    }

                    int idEliminar = AnsiConsole.Ask<int>(
                        "Ingrese el ID del delivery que desea eliminar:"
                    );

                    bool eliminado = deliveryService.Delete(idEliminar);

                    if (eliminado)
                    {
                        AnsiConsole.MarkupLine(
                            "[green]Delivery eliminado correctamente.[/]"
                        );
                    }
                    else
                    {
                        AnsiConsole.MarkupLine(
                            "[red]No existe un delivery con ese ID.[/]"
                        );
                    }

                    break;

                case "3. Agregar un delivery":

                    AnsiConsole.Clear();

                    string cliente = AnsiConsole.Ask<string>(
                        "Ingrese el nombre del cliente:"
                    );

                    string direccion = AnsiConsole.Ask<string>(
                        "Ingrese la dirección del cliente:"
                    );

                    string pedido = AnsiConsole.Ask<string>(
                        "Ingrese el pedido:"
                    );

                    deliveryService.Add(cliente, direccion, pedido);

                    AnsiConsole.MarkupLine(
                        "[green]Delivery agregado correctamente.[/]"
                    );

                    break;

                case "4. Salir":

                    AnsiConsole.Clear();

                    AnsiConsole.MarkupLine(
                        "[green]¡Fin del programa![/]"
                    );

                    running = false;

                    break;
            }
        }
    }
}
