using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTavsiye.Core.Models
{
    public class UserNote : BaseEntity
    {
        public string Note { get; set; }
        public int Score { get; set; }  
        public string UserId { get; set; }  
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public UserApp UserApp { get; set; }
    }
}
