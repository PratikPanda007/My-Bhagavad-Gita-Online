using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BhagavadGita.Models
{
    public class ChapInfoDetails
    {
        public List<ChapInfo> ChapDetails { get; set; }
    }

    public class ChapInfo
    {
        public int chId;

        public string chName;

        public string chDesc;
    }
}