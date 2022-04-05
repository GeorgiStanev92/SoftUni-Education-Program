namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            var result = RemoveBooks(db);
            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            string[] bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            foreach (var book in bookTitles)
            {
                sb.AppendLine(book);
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            //StringBuilder sb = new StringBuilder();

            //var goldenBooks = context
            //    .Books
            //    .Where(b => b.EditionType == EditionType.Gold &&
            //            b.Copies < 5000)
            //    .OrderBy(b => b.BookId)
            //    .Select(b => b.Title)
            //    .ToArray();

            //foreach (var book in goldenBooks)
            //{
            //    sb.AppendLine(book);
            //}
            //return sb.ToString().TrimEnd();

            //Both works 

            StringBuilder sb = new StringBuilder();

            var bookCopies = context.Books
                .Where(bc => bc.EditionType == EditionType.Gold &&  bc.Copies < 5000)
                .OrderBy(bc => bc.BookId)
                .Select(bc => bc.Title);

            foreach (var book in bookCopies)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksPrice = context
                .Books
                .Where(bp => bp.Price > 40)
                .OrderByDescending(bp => bp.Price)
                .Select(bp => new
                {
                    Price = bp.Price,
                    Title = bp.Title
                });

            foreach (var book in booksPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            var category = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var booksCategory = context.BooksCategories
                .Where(bc => category.Any(c => c == bc.Category.Name.ToLower()))
                .Select(bc => bc.Book.Title)
                .OrderBy(x => x);

            foreach (var title in booksCategory)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            var theDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < theDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price,
                    b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleaseDate);

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            string[] notReleased = context.Books
                .Where(b => b.ReleaseDate.HasValue &&
                        b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var book in notReleased)
            {
                sb.AppendLine(book);
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .ToArray()
                .Where(a => a.FirstName.ToLower().EndsWith(input.ToLower()))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine(author);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var contain = input.ToLower();

            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(contain))
                .Select(b => b.Title)
                .OrderBy(b => b);

            foreach (var book in books)
            {
                sb.AppendLine($"{book}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var contain = input.ToUpper();

            var books = context.Books
                .Where(b => b.Author.LastName.ToUpper().StartsWith(contain))
                .Select(b => new
                {
                    Title = b.Title,
                    BookId = b.BookId,
                    AuthorName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .OrderBy(b => b.BookId);

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList()
                .Count();

            return books;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalBookCopies = a.Books
                        .Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalBookCopies)
                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.TotalBookCopies}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var bookCategories = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks
                        .Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ToArray();

            foreach (var book in bookCategories)
            {
                sb.AppendLine($"{book.CategoryName} ${book.TotalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    MostRecentBooks = c.CategoryBooks
                        .Select(cb => cb.Book)
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .Select(b => new
                        {
                            BookTitle = b.Title,
                            ReleaseYear = b.ReleaseDate.Value.Year
                        })
                        .ToArray()
                })
                .OrderBy(c => c.CategoryName)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"--{book.CategoryName}");

                foreach (var item in book.MostRecentBooks)
                {
                    sb.AppendLine($"{item.BookTitle} ({item.ReleaseYear})");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var increasePrices = context.Books
                .Where(b => b.ReleaseDate.HasValue &&
                            b.ReleaseDate.Value.Year < 2010);

            foreach (var increase in increasePrices)
            {
                increase.Price += 5;
            }
            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return books.Count;
        }
    }
}
