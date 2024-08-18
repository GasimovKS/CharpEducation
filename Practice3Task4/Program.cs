class Book
{
    public string NameBook;
    public string Author;
    public string NameBook { get { return name; } }
    public string Author { get { return author; } }

    public Book(string name, tring author);
     { 
      this.name = name;
      this.author = author;
      }


public NewBook(string name) : this(name, "автор") { }
public NewBook() : this("книга", "автор") { }
}
