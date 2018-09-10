using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace LibraryCardCatalog
{
    class CardCatalog
    {
        private string _filename;
        public static List<Book> bookList { get; set; } = new List<Book>();


        //List<Book> bookList = new List<Book>();



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
                //TEST TO SEE IF CODE EXISTS, IT DOES (Currently)
                //Console.WriteLine("File \"{0}\" already exists.", pathString);
               // return;
            }
        }


        /*
        public void initializeBooks()
        {
            string filename;
            filename = _filename;

            XmlSerializer reader = new XmlSerializer(typeof(List<Book>));
            StreamReader file = new StreamReader(@"C:\LibraryCardCatalog\LibraryCardCatalog_Data\" + filename);

            List<Book> bookList = (List<Book>)reader.Deserialize(file);
                foreach (Book b in bookList)
                {
                    Console.WriteLine(b.ToString());
                }
           
        }*/


        public void ListBooks()
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
        public void AddBook()
        {
            string filename;
            filename = _filename;

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
         
                bookList.Add( new Book { Title = bookTitle, Author = author, Published = published });

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
            string filename;
            filename = _filename;
            XmlSerializer writer = new XmlSerializer(typeof(List<Book>));

            string folderName = @"C:\LibraryCardCatalog\";
            string pathString = Path.Combine(folderName, "LibraryCardCatalog_Data");
            pathString = Path.Combine(pathString, filename);

            FileStream file = File.Create(pathString);
            writer.Serialize(file, bookList);
            file.Close();
        }
    }
}
