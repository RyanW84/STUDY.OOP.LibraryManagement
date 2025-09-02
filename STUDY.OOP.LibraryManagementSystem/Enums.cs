using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace STUDY.OOP.LibraryManagementSystem;

internal class Enums
    {
   internal enum MenuOption
        {
        [Display(Name = "View Books")]
        ViewBooks,
        [Display(Name = "Add Book")]
        AddBook,
        [Display(Name = "Delete Book")]
        DeleteBook
        }
   internal static string GetEnumDisplayName(Enum enumValue)
        {
        var displayAttribute =
            enumValue
                .GetType()
                .GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;

        if (displayAttribute == null)
            {
            Console.WriteLine("No Enum display names found");
            }

        return displayAttribute != null ? displayAttribute.Name : enumValue.ToString();
        }
    }

