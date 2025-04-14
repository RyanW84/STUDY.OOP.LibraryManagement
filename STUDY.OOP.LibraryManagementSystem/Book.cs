using System.Xml.Linq;

namespace STUDY.OOP.LibraryManagementSystem;
internal class Book
{
    string _name;

    public string Name
    {
        get { return _name; }
        set {
        if (string.IsNullOrEmpty(value))
            {
            throw new ArgumentNullException(value);
            }
        _name = value;
        }
    }
    string _location;

  internal Book()
    {

    }
}

