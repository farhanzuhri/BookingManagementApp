﻿using API.Models;

namespace API.DTOs.Educations
{
    public class CreateEducationDto
    {
        public Guid Guid { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public float GPA { get; set; }
        public Guid UniversityGuid { get; set; }

        public static implicit operator Education(CreateEducationDto createEducationDto)
        {
            return new Education
            {
                Guid = createEducationDto.Guid,
                Major = createEducationDto.Major,
                Degree = createEducationDto.Degree,
                GPA = createEducationDto.GPA,
                UniversityGuid = createEducationDto.UniversityGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
