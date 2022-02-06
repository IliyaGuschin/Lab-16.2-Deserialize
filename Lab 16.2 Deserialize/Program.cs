using System;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Lab_16._2_Deserialize
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Выгрузка.txt";
            string CurrentRecord;
            Product CurrentProduct = new Product();
            double priceMax = 0;

            using (StreamReader sr = new StreamReader(path))
            {
                
                for (int i=0;i<5;i++)
                {
                    CurrentRecord = sr.ReadLine();
                    CurrentProduct = JsonSerializer.Deserialize<Product>(CurrentRecord);
                    if (priceMax<CurrentProduct.Price)
                    {
                        priceMax = CurrentProduct.Price;
                    }
                }
                
            }

            Console.WriteLine("Максимальная цена: {0}", priceMax);

        }

        class Product
        {
            public string Name { get; set; }
            public int Code { get; set; }
            public double Price { get; set; }
            public string ToJSONString()
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
                };

                return JsonSerializer.Serialize(this, options);
            }
        }

    }
}
