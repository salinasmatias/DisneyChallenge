using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyWorld.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            Usuarios = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<User> Usuarios { get; set; }
    }
}
