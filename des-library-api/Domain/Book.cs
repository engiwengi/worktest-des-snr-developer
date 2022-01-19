using System;

namespace des_library_api.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public Guid BorrowedBy { get; set; }
    }
}
