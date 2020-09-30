using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monafasati.Data.ModelDto
{
    public class ApplictionUser:IdentityUser
    {
        public int MyProperty { get; set; }
    }
}
