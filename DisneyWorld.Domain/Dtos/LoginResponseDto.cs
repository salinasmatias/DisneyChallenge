﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyWorld.Domain.Dtos
{
    public class LoginResponseDto
    {
        public int UserId { get; set; }
        public string Status { get; set; }
        public string Token { get; set; }
    }
}
