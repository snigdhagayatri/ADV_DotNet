using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListManager.Models
{
    public class GroceryList
    {
            [Key]
            public int Id { get; set; }

            public string Name { get; set; }
            public string Price { get; set; }
            public DateTime? PurchasedDate { get; set; }
            
            public bool IsPurchased
            {
                get
                {
                    return PurchasedDate != null;
                }
            }
        
    }
}
