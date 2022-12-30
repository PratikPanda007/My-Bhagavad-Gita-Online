using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BhagavadGita.Models
{
    public class ShlokasDetails
    {
        public int ChapterId;

        public string ChapterName;
        public List<ShlokaInfo> shlokaDetails { get; set; }
    }

    public class ShlokaInfo
    {
        public int ShlokaId;

        public int ChapterId;

        public int ShlokaSubId;

        public string Shloka;

        public string Transliteration;

        public string ShlokaTrans;

        public string Notes;

        public string Purport;
    }
}