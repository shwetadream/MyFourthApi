using System;

namespace MyFourthApi.Models
{
    public class JobModel
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}
