﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooking.Domain.Dtos
{
    public class UserSignInModel
    {
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
