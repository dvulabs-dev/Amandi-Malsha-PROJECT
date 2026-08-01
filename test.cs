using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SarasaviLibrary.DataAccess.Contexts;
class Program {
    static void Main() {
        using var db = new AppDbContext();
        var copies = db.BookCopies.Where(c => c.AccessionNumber.Contains(""K0001"")).ToList();
        Console.WriteLine($""Found {copies.Count} copies"");
        foreach(var c in copies) Console.WriteLine(c.AccessionNumber);
    }
}
