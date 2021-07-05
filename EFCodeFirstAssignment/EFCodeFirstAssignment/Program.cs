using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            using(BookDBContext db =new BookDBContext())
            {
                Publisher publish = new Publisher()
                {
                    PublisherID = 10001,
                    PublisherName = "R Rajan",
                    Country = "USA"
                };
                db.Publisher.Add(publish);

                Book book = new Book()
                {
                    BookID = 1,
                    BookName = "Let us C",
                    Publisher=publish

                };
                db.Book.Add(book);

                Member member = new Member()
                {
                    MemberID = 101,
                    MemberName = "Abhishek"
                };
                db.Member.Add(member);

                Review review = new Review()
                {
                    ReviewID = 1001,
                    ReviewText = "Very wonderful Book",
                    BookID = 1,
                    MemberID = 101
                };
                db.Review.Add(review);
                db.SaveChanges();

                Console.WriteLine("Records Inserted....");
                Console.ReadLine();
            }
        }
    }
}
