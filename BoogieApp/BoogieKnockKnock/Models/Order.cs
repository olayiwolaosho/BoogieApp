using System;
using System.Collections.Generic;
using System.Text;

namespace BoogieApp.BoogieKnockKnock.Models
{
    public class Order
    {
        public IEnumerable<string> Shopname { get; set; }
        public IEnumerable<string> orders { get; set; }
        public string orderprogress  { get; set; }
       // public DateTime Date { get; set; }
        public string Date { get; set; }
    }
}
