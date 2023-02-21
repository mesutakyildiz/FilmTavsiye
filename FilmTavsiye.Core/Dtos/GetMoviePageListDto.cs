using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTavsiye.Core.Dtos
{
    public class GetMoviePageListDto
    {
        public int page { get; set; }
        public int pageSize { get; set; }  
    }
}
