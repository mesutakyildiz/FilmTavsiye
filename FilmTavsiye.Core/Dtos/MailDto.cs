using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTavsiye.Core.Dtos
{
    public class MailDto
    {
       public List<string> EmailAdress { get; set; }
       public int MovieId { get; set; }
    }
}
