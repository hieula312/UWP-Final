using APITEST.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace APITEST.Controllers
{
    public class ProductsController : ApiController
    {
        private List<Product> products = new List<Product>();
        // GET: api/Products

        //public IEnumerable<Product> Get()
        //{
        //    GetList();
        //    return products.AsEnumerable();
        //}

        public HttpResponseMessage Get()
        {
            GetList();
            if(products.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, products.AsEnumerable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not Found Product");
          
        }

        // GET: api/Products/5
        public HttpResponseMessage Get(int id)
        {
            GetList();
            if (products.Count > 0)
            {
                var product = products.Where(p => p.Id == id);
                return Request.CreateResponse(HttpStatusCode.OK, product.AsEnumerable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not Found Product");
        }

        // POST: api/Products
        public HttpResponseMessage Post([FromBody]int id)
        {
            if (products.Count > 0)
            {
                var product = products.Where(p => p.Id == id);
                return Request.CreateResponse(HttpStatusCode.OK, product.AsEnumerable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not Found Product");
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpGet]
        // DELETE: api/Products/5
        public HttpResponseMessage Delete(int id)
        {
            GetList();
            if (products.Count > 0)
            {
                var product = products.Where(p => p.Id == id);
                products.Remove(product as Product);
                return Request.CreateResponse(HttpStatusCode.OK, products.AsEnumerable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not Found Product");
        }

        private void GetList()
        {
            products.Add(new Product()
            {
                Id = 1,
                Name = "Product 1",
                Price = 10000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2020-01-13"),
                Thumbnails = "image/upload/v1587907877/rpnm2n9uuxi5aoeyb093.jpg"
            });
            products.Add(new Product()
            {
                Id = 2,
                Name = "Product 2",
                Price = 5000,
                Status = Product.ProductStatus.DEACTIVE,
                CreatedAt = DateTime.Parse("2020-03-13"),
                Thumbnails = "image/upload/v1587907877/rm7bs0llyz9dzjuiomld.jpg"
            });
            products.Add(new Product()
            {
                Id = 3,
                Name = "Product 3",
                Price = 10000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2020-01-13"),
                Thumbnails = "image/upload/v1587907877/rpnm2n9uuxi5aoeyb093.jpg"
            });
            products.Add(new Product()
            {
                Id = 4,
                Name = "Product 4",
                Price = 15000,
                Status = Product.ProductStatus.ACTIVE,
                CreatedAt = DateTime.Parse("2020-04-25"),
                Thumbnails = "image/upload/v1587907877/nkcoz6ruhohwbvgu3gir.jpg"
            });
            products.Add(new Product()
            {
                Id = 5,
                Name = "Product 5",
                Price = 22000,
                Status = Product.ProductStatus.DELETE,
                CreatedAt = DateTime.Parse("2019-01-16"),
                Thumbnails = "image/upload/v1587907877/fl0wkcwe7le8tfr8gyvo.jpg"
            });
        }
    }
}
