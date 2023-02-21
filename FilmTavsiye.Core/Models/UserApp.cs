using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmTavsiye.Core.Models
{
    public class UserApp : IdentityUser
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public ICollection<UserNote> UserNotes { get; set; }
     
    }

   
}