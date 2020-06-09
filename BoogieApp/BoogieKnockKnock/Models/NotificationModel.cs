using System;
using System.Collections.Generic;
using System.Text;

namespace BoogieApp.BoogieKnockKnock.Models
{
    class NotificationModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Seen { get; set; }
        public string ImageUrl { get; set; }

    }
}
