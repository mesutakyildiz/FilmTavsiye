using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTavsiye.Core.Dtos
{
    public class MovieWithUserNoteDto : MovieDto
    {
        public ICollection<UserNoteDto> UserNotes  {get;set;}
    }
}
