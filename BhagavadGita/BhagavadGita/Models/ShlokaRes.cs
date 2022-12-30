using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BhagavadGita.Models
{
    public class ShlokaRes
    {
        public int ChapterNum;

        public string ChapterName;

        public List<ShlokaSubInfo> ShlokaSubInfo { get; set; }
    }

    public class ShlokaSubInfo
    {
        public int ShlokaSubId;

        public string Shloka;

        public string Transliteration;

        public string ShlokaTrans;

        public string Notes;

        public string Purport;
    }
}