using System;
using System.Linq;
using SarasaviLibrary.DataAccess.Contexts;
class Program {
    static void Main() {
        using var db = new AppDbContext();
        var copies = db.BookCopies.ToList();
        Console.WriteLine($"Total {copies.Count} copies");
        foreach(var c in copies) Console.WriteLine(c.AccessionNumber);
    }
}
