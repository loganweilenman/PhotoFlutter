using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoFlutter.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhotoFlutter.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price =1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price =3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price =16.99M },
        };


        /// <summary>
        /// URL: /api/products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        /// <summary>
        /// URL: /api/products/id
        /// </summary>
        /// <returns></returns>
        public Product GetProductById(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return product;
        }

        /// <summary>
        /// URL: /api/products/?category=category
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return products.Where(
                (p) => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

    }
}
