using System;
using System.Collections.Generic;

namespace TestForInterView.Model.Entity
{
    public partial class Teacher
    {
        public int Tid { get; set; }
        public string TeacherName { get; set; } = null!;
        public int Age { get; set; }
        public string Sex { get; set; } = null!;
        public byte[]? Image { get; set; }
        public int? Sid { get; set; }
    }
}
