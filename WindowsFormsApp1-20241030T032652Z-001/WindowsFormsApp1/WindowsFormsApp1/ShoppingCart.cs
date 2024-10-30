using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class ShoppingCart
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public decimal GetTotalPrice()
        {
            return products.Sum(p => p.Price * p.Quantity);
        }

        public int GetTotalQuantity()
        {
            return products.Sum(p => p.Quantity);
        }

        public void Clear()
        {
            products.Clear();
        }
    }
}
