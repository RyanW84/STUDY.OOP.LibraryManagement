using Spectre.Console;

namespace STUDY.OOP.LibraryManagementSystem;

internal static class BooksController
    {

    internal static void ViewBooks()
        {
        AnsiConsole.MarkupLine("[yellow]List of Books: [/]");
        foreach (var book in MockDatabase.Books)
            {
            AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
            }
        AnsiConsole.MarkupLine("[blue]Press any Key to continue[/]");
        Console.ReadKey();
        }

    internal static void AddBook()
        {
        string title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
        if (MockDatabase.Books.Contains(title))
            {
            AnsiConsole.MarkupLine($"[red]{title} book already exists[/]");
            }
        else
            {
            MockDatabase.Books.Add(title);
            AnsiConsole.Markup($"[green]Book: {title} added succesfully[/]");
            }
        Console.ReadKey();
        }

    internal static void DeleteBook()
        {
        if (MockDatabase.Books.Count == 0)
            {
            AnsiConsole.MarkupLine("[red]No Books available to delete[/]");
            Console.ReadKey();
            return;
            }

        var bookToDelete = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("Select a [red]Book[/] to delete: ")
        .AddChoices(MockDatabase.Books));

        if (MockDatabase.Books.Remove(bookToDelete))
            {
            AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
            }
        else
            {
            AnsiConsole.MarkupLine("[red] Book not found[/]");
            }

        AnsiConsole.MarkupLine("Press any key to continue.");
        Console.ReadKey();
        }
    }

