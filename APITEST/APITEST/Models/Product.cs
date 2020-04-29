using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APITEST.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Thumbnails { get; set; }
        public DateTime CreatedAt { get; set; }
        public ProductStatus Status { get; set; }
        public enum ProductStatus
        {
            ACTIVE = 1, DEACTIVE = 0, DELETE = 2
        }
    }
}