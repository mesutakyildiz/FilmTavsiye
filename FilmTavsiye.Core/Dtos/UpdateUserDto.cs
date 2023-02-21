using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTavsiye.Core.Dtos
{
    public class UpdateUserDto
    {
        public string Id { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
