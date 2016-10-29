namespace DashCache.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentsCourses
    {
        [Key]
        public int StudentCourseId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
