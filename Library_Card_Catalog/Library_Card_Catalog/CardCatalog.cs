using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace LibraryCardCatalog
{
    class CardCatalog
    {
        private string _filename;
        //private Book[] books;

        public CardCatalog(string filename)
        {
            _filename = filename;

            string folderName = @"C:\LibraryCardCatalog\";
            string pathString = Path.Combine(folderName, "LibraryCardCatalog_Data");
            Directory.CreateDirectory(pathString);
            pathString = Path.Combine(pathString, filename);

            if (!File.Exists(pathString))
            {
                using (FileStream fs = File.Create(pathString)) { }
            }
            else
            {
                byte[] readBuffer = File.ReadAllBytes(pathString); //TODO comeback to this part
            }
            try
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(pathString); //write bytes in order to read bytes
                foreach (byte b in readBuffer)
                {
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ListBooks(string listbooks)
        {
            Console.Clear();

            Console.WriteLine("Here is a complete List of Books In List: \n\n");

            string filename;
            filename = _filename;

            XmlSerializer reader = new XmlSerializer(typeof(List<Book>));
            StreamReader file = new StreamReader(@"C:\LibraryCardCatalog\LibraryCardCatalog_Data\" + filename);

            try
            {
                List<Book> bookList = (List<Book>)reader.Deserialize(file);
                foreach (Book b in bookList)
                {
                    Console.WriteLine(b.ToString());
                }
            }
            catch
            {
                Console.WriteLine("You have not added any books to this list.\nPlease add books to continue");
            } 
            file.Close();
            Console.ReadLine();
        }

        public void AddBook(string books)
        {
            //call in filename for pathing
            string filename;
            filename = _filename;

            Console.Clear();

            List<Book> bookList = new List<Book>();

            bool addAnotherBook = true;
            do
            {
                Console.Clear();
                //
                Console.WriteLine("Please Enter A book Title: ");
                string bookTitle = Console.ReadLine();
                //
                Console.WriteLine("Please Enter The Book's Author: ");
                string author = Console.ReadLine();
                //
                Console.WriteLine("Please Enter The Published Year: ");
                int published = int.Parse(Console.ReadLine());
                //
                bookList.Add(new Book { Title = bookTitle, Author = author, Published = published });
                Console.Clear();
                Console.WriteLine("Book Successfully Added!\n" +
                    "Add Another Book? Y/N");
                string yesOrNo = Console.ReadLine();
                if (yesOrNo == "n" || yesOrNo == "N")
                {
                    addAnotherBook = false;
                } else
                {
                    addAnotherBook = true;
                }
            } while (addAnotherBook == true);

            XmlSerializer writer = new XmlSerializer(typeof(List<Book>));

            string folderName = @"C:\LibraryCardCatalog\";
            string pathString = Path.Combine(folderName, "LibraryCardCatalog_Data");
            pathString = Path.Combine(pathString, filename);

             FileStream file = File.Create(pathString);
             writer.Serialize(file, bookList);
             file.Close();
        }

        public void Save()
        {

        }
    }
}
