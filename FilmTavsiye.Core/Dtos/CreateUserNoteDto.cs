using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTavsiye.Core.Dtos
{
    public class CreateUserNoteDto
    {
        public string Note { get; set; }
        public int Score { get; set; }
        public int MovieId { get; set; }
    }
}
