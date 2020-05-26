using System;
using System.Collections.Generic;
using System.Text;

namespace BoogieApp.BoogieKnockKnock.Models
{
    class ShoppingCategoriesModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
