using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BhagavadGita.Models
{
    public class DD_ChaptersModel
    {
        public List<DD_ChaptersList> ChDetails { get; set; }
    }

    public class DD_ChaptersList
    {
        public int chId;

        public string chName;
    }
}