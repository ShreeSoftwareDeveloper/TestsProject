using System;
using System.Collections.Generic;

namespace TestForInterView.Model.Entity
{
    public partial class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Class { get; set; } = null!;
        public byte[]? Image { get; set; }
        public int? Tid { get; set; }
        public int? Sid { get; set; }
    }
}
