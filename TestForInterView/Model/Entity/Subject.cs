using System;
using System.Collections.Generic;

namespace TestForInterView.Model.Entity
{
    public partial class Subject
    {
        public int Sid { get; set; }
        public string SubjectName { get; set; } = null!;
        public string Class { get; set; } = null!;
        public string Lanaguage1 { get; set; } = null!;
        public string Lanaguage2 { get; set; } = null!;
        public string Lanaguage3 { get; set; } = null!;
    }
}
