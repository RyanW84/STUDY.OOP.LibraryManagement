using Spectre.Console;
using static STUDY.OOP.LibraryManagementSystem.Enums; 

namespace STUDY.OOP.LibraryManagementSystem
    {
    internal static class UserInterface
        {
      
        internal static void MainMenu()
            {
            while (true)
                {
                Console.Clear();

                var choice = AnsiConsole.Prompt(new SelectionPrompt<MenuOption>()
                .Title("What do you want to do?")
                .AddChoices(Enum.GetValues(typeof(MenuOption)).Cast<MenuOption>())
                .UseConverter(choice => GetEnumDisplayName(choice)));

                switch (choice)
                    {
                    case MenuOption.ViewBooks:
                    BooksController.ViewBooks();
                    break;
                    case MenuOption.AddBook:
                    BooksController.AddBook();
                    break;
                    case MenuOption.DeleteBook:
                    BooksController.DeleteBook();
                    break;
                    }
                }

            }
        }
    }
