using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public class Teacher : ApplicationUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Teacher()
        {

        }
        public Teacher(string email, string firstName, string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
