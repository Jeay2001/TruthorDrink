using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TruthOrDrink.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("Name"), Indexed, NotNull]
        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string QrCode { get; set; }

        public int FriendId { get; set; }

        public List<User> Friends { get; set; }
    }
}
