using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLinqAssign
{
    public class Operators
    {
        private List<Author> authList;
        private List<Paint> paints;

        public Operators()
        {
            SeedData();

        }

        public void SeedData()
        {
            Author Brad = new Author { Id = 111, Name = "Brad", Surname = "Pit", YearsOld = 25 };
            Author Alan = new Author { Id = 112, Name = "Alan", Surname = "Noris", YearsOld = 50 };
            Author Mark = new Author { Id = 113, Name = "Mark", Surname = "Roosvelt", YearsOld = 42 };
            Author Arnold = new Author { Id = 114, Name = "Arnold", Surname = "Cluni", YearsOld = 50 };

            authList = new List<Author> { Brad, Alan, Mark, Arnold };

            Paint paint1 = new Paint { Id = 222, Owner = "Chack Noris", Price = 1234, Title = "Modernist" , Author = Brad };
            Paint paint2 = new Paint { Id = 223, Owner = "Joe Biden", Price = 234, Title = "Baroc",Author  = Alan };
            Paint paint3 = new Paint { Id = 224, Owner = "Jackie Chan", Price = 234, Title = "Medieval" , Author = Mark };
            Paint paint4 = new Paint { Id = 225, Owner = "Mihai Barbarosa", Price = 867, Title = "Cultural" , Author = Arnold };
            Paint paint5 = new Paint { Id = 226, Owner = "Mihai Barbarosa", Price = 120, Title = "Cultural" , Author = Arnold };

            paints = new List<Paint> { paint1, paint2, paint3, paint4 , paint5 };
        }
        public void JoinMethod()
        {
            Console.WriteLine("Join Method");
            var querryResult = authList.Join(paints,
                author => author,
                paint => paint.Author,
                (author, paint) => new { AuthorName = author.Name , paint.Id });

            foreach (var item in querryResult)
            {
                Console.WriteLine($"Author: {item.AuthorName}, Paint Title: {item.Id}");
            }
            Console.WriteLine("-------------------------------------");
        }

        public void ProjectionOperator()
        {
            Console.WriteLine("Select querry method with filtering operator");
            var querryResult = paints.Where(p => p.Price > 200 && p.Price < 900).Select( (p) => new {  p.Id , p.Title});

            foreach (var item in querryResult)
            {
                Console.WriteLine($"Paint: {item.Id} ,  {item.Title}");
            }
            Console.WriteLine("-------------------------------------");
        }


        public void SortingOperators()
        {
            Console.WriteLine("Sorting Operators");
            var querryResult = paints.OrderBy(b => b.Price).ThenBy(b => b.Owner);

            foreach (var item in querryResult)
            {
                Console.WriteLine($"Paint: {item.Id} , Owner = {item.Owner} , Price = {item.Price}");
            }
            Console.WriteLine("-------------------------------------");
        } 
        public void GroupingOperators()
        {
            Console.WriteLine("Grouping Operators");
            var groupByAuthor = paints.GroupBy(paint => paint.Author)
                                  .Select(group => new
                                  {
                                      AuthorName = group.Key.Name + " " + group.Key.Surname,
                                      PaintCount = group.Count(),
                                      TotalPrice = group.Sum(paint => paint.Price)
                                  });

            foreach (var group in groupByAuthor)
            {
                Console.WriteLine($"Author: {group.AuthorName}, Paint Count: {group.PaintCount}, Total Price: {group.TotalPrice}");
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
        } 
        
        public void ConversionsOperators()
        {
            Console.WriteLine("Conversion Operation");
            var expensivePaintsList = paints.Where(paint => paint.Price > 200).ToList();
            var uniqueAuthorsArray = paints.Select(paint => paint.Title).Distinct().ToArray();

            Console.WriteLine("ToList");
            foreach(var item in expensivePaintsList)
            {
                Console.WriteLine($"Id: {item.Id} , Owner: {item.Owner} , Price: {item.Price}");
            }

            Console.WriteLine("Array ");
            foreach(var item in uniqueAuthorsArray)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
        }
        public void ConcatinationOperators()
        {
            Console.WriteLine("Concat Oper");
            var result = authList.Select(author => author.Id).Concat(paints.Select(paints => paints.Id)).ToList();  

            foreach(var item in result)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------");

        } 
        public void AggregationOperators()
        {
            Console.WriteLine("Aggregation Oper");

            int count  = authList.Count();
            Console.WriteLine($"Number of authors: {count}");
            var minValue = paints.Min(paint => paint.Price);
            Console.WriteLine($"Min Price: {minValue}");
            var maxValue = paints.Max(paint => paint.Price);
            Console.WriteLine($"Max Price: {maxValue}");
            var sum  = paints.Sum(paint => paint.Price);
            Console.WriteLine($"Sum: {sum}");


            Console.WriteLine();
            Console.WriteLine("--------------------------------");
        }
        public void QuantifierOperations()
        {
            Console.WriteLine("Quantifier Operations");

            if (paints.All(n => n.Price < 300))
            {
                Console.WriteLine("All the paints are less than 300");

            }
            else
            {
                Console.WriteLine("There are no paints with Price less than 300");
            }

            if (paints.Any(n => n.Price < 500))
            {
                Console.WriteLine("There are paiints less than 500");

            }
            else
            {
                Console.WriteLine("There are no paints with Price less than 500");

            }
            Console.WriteLine("---------------------------------------- ");
        }

        public void PartitionOperations()
        {
            Console.WriteLine("Partiotion");
            List<string> str = new List<string> { "12", "13", "a", "b", "a" };
            List<string> str2 = new List<string> { "a", "b", "42", "23" };

            Console.WriteLine("Skip");
            var result = str.Skip(2).ToList();
            Print(result);
            Console.WriteLine("\nTake");
            var result2 = str2.Take(2).ToList();
            Print(result2);

            Console.WriteLine();
            Console.WriteLine("--------------------------------------");

        }
        public void GenerationOperations()
        {
            Console.WriteLine("Generation Oper");
            var numbers = Enumerable.Range(1, 10);
            var repeatedValues = Enumerable.Repeat("Hello", 3);

            foreach (var number in numbers) 
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            foreach (var item in repeatedValues) 
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------");
        }
        public void SetOperations()
        {
            Console.WriteLine("Set Oper");
            List<string> str = new List<string> { "12", "13", "a", "b", "a" };
            List<string> str2 = new List<string> { "a", "b", "42", "23" };

            var result = str.Intersect(str2).ToList();
            Print(result);

            var result2 = str.Distinct().ToList();
            Print(result2);

            var dupl = str.Union(str2).ToList();
            Print(dupl);

            Console.WriteLine();
            Console.WriteLine("------------------------------------------");

        }
        public void ElementOperators()
        {
            Console.WriteLine("Element Oper");
            var result = paints.Where(p => p.Price > 500).FirstOrDefault();

            Console.WriteLine($"Id: {result.Id} , Price: {result.Price}");


            var result2 = paints.Where(p => p.Price > 500).LastOrDefault();

            Console.WriteLine($"Id: {result2.Id} , Price: {result2.Price}");

            Console.WriteLine();
            Console.WriteLine("-----------------------------");
        }

        public void Print(List<string> items)
        {
            Console.WriteLine();
            foreach (var item in items)
            {
                Console.Write(item+ " ");
            }
        }


    }
}
