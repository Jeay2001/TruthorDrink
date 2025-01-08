using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TruthOrDrink.Abstractions;

namespace TruthOrDrink.MVVM.Models
{
    [Table("User")]
    public class User : TableData
    {

        [Column("Name"), Indexed, NotNull]
        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string QrCode { get; set; }
        
        public int FriendId { get; set; }

        [Ignore]
        public List<User> Friends { get; set; }
    }
}
