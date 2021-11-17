using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyWorld.Domain.Dtos
{
    public class UserDtoForCreation
    {
        [StringLength(50, MinimumLength = 4)]
        public string Username { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string Email { get; set; }

        [StringLength(30, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
