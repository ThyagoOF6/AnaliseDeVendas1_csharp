using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Entities;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

            Console.Write("Entre o caminho do arquivo: ");
            string path = Console.ReadLine();

            try
            {
                List<Sale> list = new List<Sale>();

                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        list.Add(new Sale(
                            int.Parse(fields[0]),
                            int.Parse(fields[1]),
                            fields[2],
                            int.Parse(fields[3]),
                            double.Parse(fields[4])
                        ));
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Cinco primeiras vendas de 2016 de maior preço médio ");
                var newList = list
                    .Where(s => s.Year == 2016)
                    .OrderByDescending(s => s.AveragePrice())
                    .Take(5)
                    .ToList();

                newList.ForEach(Console.WriteLine);

                double sum = list
                    .Where(s => s.Month == 1 || s.Month == 7)
                    .Where(s => s.Seller == "Logan")
                    .Sum(s => s.Total);

                Console.WriteLine();
                Console.WriteLine($"Valor total vendido pelo vendedor Logan nos meses 1 e 7 = {sum}");
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }