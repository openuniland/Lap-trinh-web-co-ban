using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BtlWebForm.Entity
{
    public class ProductEntity
    {
        public ProductEntity(int iD, int Quantity)
        {
            ID = iD;
            this.Quantity = Quantity;
        }
        public ProductEntity() { }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Trademark { get; set; }
        public float Price { get; set; }
        public float Sale { get; set; }
        public List<string> ListImage { get; set; }
        public string Info { get; set; }
        public int Quantity { get; set; }
        public string Slug { get; set; }
        public string Category { get; set; }

        public DateTime TimeAdd { get; set; }
        
    }
}