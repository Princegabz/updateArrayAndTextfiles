using System;
using System.IO;
using System.Threading;
using Xceed.Wpf.Toolkit;

namespace updateArrayAndTextfiles
{
    internal class Program
    {
        private static StreamReader fileIn;
        private static StreamWriter fileOut;
        private static string[] id = new string[3];
        private static string[] name = new string[3];
        private static string[] price = new string[3];

        static void Main(string[] args)
        {
            calc c = new calc();
            Console.WriteLine(c.hello());
            Console.WriteLine(c.pizza());

            Thread.Sleep(5000);

            fillArray();
            int choice = 1;
            while (choice == 1)
            {
                printArray();
                Console.WriteLine("Would you like to update a products price? " + 
                                  "Enter 1 for YES: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    enterNewValues();
                }
            }
        }

        public static void fillArray() //Create
        {
            try
            {
                int x = 0;
                string proj = "";
                if (File.Exists("Products.txt"))
                {
                    fileIn = new StreamReader("Products.txt");
                    while ((proj = fileIn.ReadLine()) != null)
                    {
                        id[x] = proj;
                        proj = fileIn.ReadLine();
                        name[x] = proj;
                        proj = fileIn.ReadLine();
                        price[x] = proj;
                        x += 1;
                    }
                    fileIn.Close();
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("The following error has occured: "+ ex.ToString());
            }
        }

        public static void printArray()
        {
            Console.Clear();
            Console.WriteLine("PRINT FROM THE PRODUCTS TEXT FILE");
            Console.WriteLine("**********************************");
            for (int y = 0; y < 3; y++)
            {
                Console.WriteLine("ID: "+ id[y]);
                Console.WriteLine("PRODUCT: "+ name[y]);
                Console.WriteLine("PRICE: "+ price[y]);
                Console.WriteLine("******************************");
            }

        }

        public static void enterNewValues() //Update
        {
            Console.Clear();
            Console.WriteLine("Enter the product ID to edit: ");
            string strID = Console.ReadLine();
            Boolean change = false;
            Boolean productFound = false;

            for (int y = 0; y < 3; y++)
            {
                if (strID.Equals(id[y]))
                {
                    Console.WriteLine("Enter the new product price: ");
                    price[y] = Console.ReadLine();
                    change = true;
                    productFound = true;
                }
            }
            if (productFound == false)
            {
                Console.WriteLine("The product ID you entered cannot be located!");

            }
            if (change == true)
            {
                writeBackToFile();
            }
        }

        public static void writeBackToFile()
        {
            try
            {
                File.Delete("Products.txt");// an
                fileOut = new StreamWriter("Products.txt", true);
                for (int y = 0; y < 3; y++)
                {
                    fileOut.WriteLine(id[y]);
                    fileOut.WriteLine(name[y]);
                    fileOut.WriteLine(price[y]);

                }
                fileOut.Close();
                Console.WriteLine("Product file updated successfully!");


            }
            catch(Exception ex)
            {
                Console.WriteLine("The following error had occured: "+ ex.ToString());
            }
            printArray();

        }
    }

    internal class calc
    {
        public string hello()
        {
            return "I am from the future, please give me a donut";
        }
        public string pizza()
        {
            return "round food from the past";
        }
    }
}
