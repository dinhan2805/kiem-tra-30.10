using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Product
    {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public Image Image { get; set; }
            public int Quantity { get; set; }

            public Product(string name, decimal price, Image image, int quantity)
            {
                Name = name;
                Price = price;
                Image = image;
                Quantity = quantity;
            }
        }
   
}
