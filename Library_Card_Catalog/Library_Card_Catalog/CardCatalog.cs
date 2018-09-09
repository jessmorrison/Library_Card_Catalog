using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


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
            string pathString = System.IO.Path.Combine(folderName, "LibraryCardCatalog_Data");
            System.IO.Directory.CreateDirectory(pathString);
            pathString = System.IO.Path.Combine(pathString, filename);

            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString)) { }
            }
            else
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(pathString); //TODO comeback to this part
            }

            /* // Read and display the data from your file.
            try
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(pathString); //write bytes in order to read bytes
                foreach (byte b in readBuffer)
                {
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }*/
        }

        public void ListBooks(string listbooks)
        {
            Console.Clear();
            Console.WriteLine("Here is a complete List of Books In List: \n\n");

            string filename;
            filename = _filename;

            XmlSerializer reader = new XmlSerializer(typeof(List<Book>));
            StreamReader file = new StreamReader(@"C:\LibraryCardCatalog\LibraryCardCatalog_Data\" + filename);

            List<Book> bookList = (List<Book>)reader.Deserialize(file);
                foreach (Book b in bookList)
                {
                    Console.WriteLine(b.ToString());
                }

            file.Close();

            Console.ReadLine();
        }

        public void AddBook(string books)
        {
            string filename;
            filename = _filename;
            Console.Clear();

            Console.WriteLine("Please Specify The Number of Books You Would Like To Add To the Catalog: \n");
                int TotalBooks = int.Parse(Console.ReadLine());

            Console.Clear();

            List<Book> bookList = new List<Book>();

          
            for (int index = 0; index < TotalBooks; index++)
            {

                Console.WriteLine("Please Enter Book #" + (index + 1) + "'s information" );

                Console.WriteLine("Please Enter A book Title: ");
                string bookTitle = Console.ReadLine();

                Console.WriteLine("Please Enter The Book's Author: ");
                string author = Console.ReadLine();

                Console.WriteLine("Please Enter The Published Year: ");
                int published = int.Parse(Console.ReadLine());

                bookList.Add(new Book { Title = bookTitle, Author = author, Published = published });
                Console.Clear();
                
            }

                //------UI END------
                Console.ReadLine();

                XmlSerializer writer = new XmlSerializer(typeof(List<Book>));

                string folderName = @"C:\LibraryCardCatalog\";
                string pathString = System.IO.Path.Combine(folderName, "LibraryCardCatalog_Data");
                pathString = Path.Combine(pathString, filename);

                FileStream file = File.Create(pathString);

                writer.Serialize(file, bookList);
                file.Close();  
        }
        public void Save() { } //prob not void
    }
}
