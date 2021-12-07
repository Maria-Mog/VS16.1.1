using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace VS16._1._1
{
    class Program
    {
        //Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».
        static void Main(string[] args)
        {
            Product[] product = new Product[5];
            product[0] = new Product();
            product[1] = new Product();
            product[2] = new Product();
            product[3] = new Product();
            product[4] = new Product();
            foreach (var i in product)
            {
                i.DataInput();
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(product, options);
            File.WriteAllText("Java/Products.json", jsonString);            
            Console.ReadKey();
        }
    }
    class Product
    {
        public int codeProduct { get; set; }
        public string nameProduct { get; set; }
        public double priceProduct { get; set; }
        public void DataInput()
        {
            Console.WriteLine("Товар #");
            Console.WriteLine("Введите «Код товара»");
            codeProduct = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите «Название товара»");
            nameProduct = Console.ReadLine();
            Console.WriteLine("Введите  «Цена товара»");
            priceProduct = Convert.ToDouble(Console.ReadLine());
        }
    }
}
