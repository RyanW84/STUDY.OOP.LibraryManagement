using Spectre.Console;

List<string> books =
[
    "1984",
    "To Kill a Mockingbird",
    "The Great Gatsby",
    "1984",
    "The Catcher in the Rye",
    "Pride and Prejudice",
    "The Lord of the Rings",
    "The Hobbit",
    "Fahrenheit 451",
    "Moby Dick",
    "War and Peace",
    "Crime and Punishment",
    "The Odyssey",
    "Brave New World",
    "Jane Eyre",
    "Wuthering Heights",
    "The Divine Comedy",
    "Hamlet",
    "Macbeth",
    "The Iliad",
];

while (true)
{
    Console.Clear();

    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOption>()
            .Title("What do you want to do next?")
            .AddChoices(Enum.GetValues<MenuOption>())
    );

    switch (choice)
    {
        case MenuOption.Viewbooks:
            viewBooks();
            break;
        case MenuOption.AddBook:
            var title = AnsiConsole.Ask<string>(
                "Enter the [green]name[/] of the book you want to add:"
            );

            if (books.Contains(title))
            {
                AnsiConsole.MarkupLine($"The book [red]{title}[/] already exists in the library.");
            }
            else
            {
                books.Add(title);
                AnsiConsole.MarkupLine(
                    $"The book [green]{title}[/] has been added to the library."
                );
            }

            Console.ReadKey();
            break;
        case MenuOption.DeleteBook:
            if (books.Count is 0)
            {
                AnsiConsole.MarkupLine("No books available to delete. Press Any Key to Continue.");
                Console.ReadKey();
                return;
            }
            var bookToDelete = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select the book you want to delete:")
                    .AddChoices(books)
            );

            if (books.Remove(bookToDelete))
            {
                AnsiConsole.MarkupLine(
                    $"The book [green]{bookToDelete}[/] has been removed from the library."
                );
            }
            else
            {
                AnsiConsole.MarkupLine(
                    $"The book [red]{bookToDelete}[/] could not be found in the library."
                );
            }

            Console.WriteLine("Press Any Key to Continue.");
            Console.ReadKey();
            break;
    }
}

void viewBooks()
{
    AnsiConsole.MarkupLine("You chose to view books. Press Any Key to Continue.");

    foreach (var book in books)
    {
        AnsiConsole.MarkupLine($"[cyan]{book}[/]");
    }
    AnsiConsole.MarkupLine("Press Any Key to Continue.");
    Console.ReadKey();
}

enum MenuOption
{
    Viewbooks,
    AddBook,
    DeleteBook,
}
