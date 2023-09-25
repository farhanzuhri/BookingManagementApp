﻿namespace API.Models
{
    public class Education : Date
    {
        public Guid Guid { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public Boolean Gpa { get; set; }
        public Guid UniversityGuid { get; set; }
        
    }
}