using System;

namespace ProjectPartA_A1

{
    class Program
    {
        struct Article
        {
            public string Name;
            public decimal Price;
        }

        const int _maxNrArticles = 10;
        const int _maxArticleNameLength = 20;
        const decimal _vat = 0.25M;

        static Article[] articles = new Article[_maxNrArticles];
        static int nrArticles;

        static void Main(string[] args)
        {
 System.Console.WriteLine("Welcome to Project Part A1");

            ReadArticles();
            PrintReciept();
        }




        private static void ReadArticles()
{
while (true) 
 {
    System.Console.WriteLine("How many articles do you want to enter (between 1 and 10)?");
 
if (!int.TryParse(System.Console.ReadLine(), out int _inputArticle) || _inputArticle < 1  || _inputArticle > 10)
{
    System.Console.WriteLine("Error, wrong input...(Choose between 1 and 10)");
continue;
}
for (int i = 0; i < _inputArticle; i++)
{
while (true) 
    {
        System.Console.WriteLine($"\nPlease enter name and price for article {i + 1} in the format name; price (example: Banana;1,99)");
        string input = System.Console.ReadLine();
        string [] parts = input.Split(';');
if (parts.Length !=2)
    {
        System.Console.WriteLine("Format error! (Write: name;price)");
continue;
    }

string name = parts [0].ToLower();
string _priceInput = parts [1].ToLower();

if (name.Length > _maxArticleNameLength || string.IsNullOrEmpty(name))
    {
        System.Console.WriteLine("Name error!");
continue;
    }
if (!decimal.TryParse(_priceInput, out decimal price) || price <= 0)
    {
        System.Console.WriteLine("Invalid price...");
continue;
    }
if (nrArticles >= _maxNrArticles)
    {
        System.Console.WriteLine("Maximum number of articles reached!");
return;
    }
        articles[nrArticles] = new Article {Name = name, Price = price};
        nrArticles ++;
        break;
        }
     }
     break;
  }
}




private static void PrintReciept()

{
if (nrArticles == 0)
    {
        System.Console.WriteLine("No articles to print.");
        return;
    }
        System.Console.WriteLine("\n-----------------------------------------------");
        System.Console.WriteLine("Let's print a reciept!");
        System.Console.WriteLine($"Purchase date: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        System.Console.WriteLine($"\nNumber of items purchased: {nrArticles}");

    decimal totalPrice = 0;

System.Console.WriteLine($"{"#",-1}{"Name",10} {"Price",20}");


for (int i = 0; i < nrArticles; i++)
    {
        System.Console.WriteLine($"{i+1,-1}{articles[i].Name,10} {articles[i].Price,20:C}");
        totalPrice += articles[i].Price;
    }

  
decimal vatAmount = totalPrice * _vat;
    System.Console.WriteLine($"\n{"Total price:",10}{totalPrice,20:C}");
    System.Console.WriteLine($"{"Includes VAT (25%):",10}{vatAmount,13:C}");
    System.Console.WriteLine("-----------------------------------------------");
        }
    }
}

