using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ProjectPartA_A2
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
        static int nrArticles = 0;

        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to Project Part A2");

            int menuSel = 4;
            do
            {
                menuSel = MenuSelection();
                MenuExecution(menuSel);

            } while (menuSel != 4);
        }




    private static int MenuSelection() 
//Your code for menu selectionivate static int MenuSelection() = DONE
        
    {
            int menuSel = 4;
        
            System.Console.WriteLine($"\nTotal articles entered: {nrArticles}");
            System.Console.WriteLine("Menu");
            System.Console.WriteLine("1. Enter an article");
            System.Console.WriteLine("2. Remove an article");
            System.Console.WriteLine("3. Print reciept");
            System.Console.WriteLine("4. Quit");

            
if (int.TryParse(Console.ReadLine(), out menuSel) && menuSel >= 1 && menuSel <= 4)
    {
        return menuSel;
    }
else 
    {
        System.Console.WriteLine("Incorrect! Please choose between 1 and 4!");
        return MenuSelection();
    }
}





        private static void MenuExecution(int menuSel)
 //Your code for execution based on the menu selection = DONE

    {        
try
    {
Console.Clear();
        
    switch (menuSel)
        {
            case 1:
            ReadAnArticle();
            break;
                
            case 2:
            RemoveAnArticle();
            break;

            case 3:
            PrintReciept();
            break;

            case 4:
            System.Console.WriteLine("Thank you for your time, have a wonderful day!");
            break;

            default:
            break;
        }
    }
                                
catch (Exception ex)
    {
        System.Console.WriteLine($"Error: {ex.Message}, Please try again");
    }
}






        private static void ReadAnArticle()
    //Your code to enter an article = DONE
{

if (nrArticles >= _maxNrArticles)
    {
        System.Console.WriteLine("Cannot add more articles. Maximum limit reached.");
        return;
    }
System.Console.WriteLine("Please enter name and price for article (example:Banana;1,99");
 
    string input = System.Console.ReadLine();
    string[] parts = input.Split(';');
    string name = parts[0].ToLower();
    string priceInput = parts[1].ToLower();
     
if (parts.Length != 2 || string.IsNullOrEmpty(name))
    {
        System.Console.WriteLine("Invalid input format... Please write: (name;price)");
        return;
    }
   
 if (name.Length > _maxArticleNameLength)
    {
        System.Console.WriteLine("ERROR... Article name is to long!");
        return;
    }
 
if (!decimal.TryParse(priceInput, out decimal price) || price <= 0)
    {
        System.Console.WriteLine("Invalid price... Please enter a valid decimal number greater than 0!");
        return;
    }
        articles[nrArticles] = new Article { Name = name, Price = price };
        nrArticles++;
    {
            System.Console.WriteLine($"Total articles entered: ");
            System.Console.WriteLine($"{name} with price {price:C} has been added.");
    }
}    







        private static void RemoveAnArticle()
//Your code to remove an article = DONE
{
if (nrArticles == 0)
    {
        System.Console.WriteLine("No articles to remove.");
        return;
    }

System.Console.WriteLine("Please! Enter the name of the article you want to remove:");
string nameToRemove = System.Console.ReadLine().Trim();
int indexToRemove = -1;

for (int i = 0; i < nrArticles; i++)
{
if (articles[i].Name.ToLower() == nameToRemove.ToLower())
    {
        indexToRemove = i;
        break;
    }
}

if (indexToRemove == -1)
    {
        System.Console.WriteLine($"Article '{nameToRemove}' not found. Please try again!");
        return;
    }

for (int i = indexToRemove; i < nrArticles - 1; i++)
    {
        articles[i] = articles[i + 1];
    }

nrArticles--; 
System.Console.WriteLine($"Article '{nameToRemove}' has been removed. Thank you!");
}






         private static void PrintReciept()
//Your code to print a receipt - DONE 
{
if (nrArticles == 0)
    {
        System.Console.WriteLine("No articles to print.");
        return;
    }
        System.Console.WriteLine("\n-----------------------------------------------");
        System.Console.WriteLine("Here is your reciept!");
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
    System.Console.WriteLine("\nThank you for shopping. Have a wonderful day!");
    System.Console.WriteLine("-----------------------------------------------");
        }
    }
}

