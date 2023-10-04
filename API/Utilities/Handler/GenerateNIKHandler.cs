﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Contracts;

namespace API.Utilities.Handler
{
    public class GenerateNIKHandler
    {
        public static string GenerateNIK(IEmployeeRepository repo)
        {
            var NIK = repo.GetAll().OrderByDescending(e => e.NIK).Select(e => e.NIK).FirstOrDefault();

            int lastNik = 0;
            if (!string.IsNullOrEmpty(NIK) && int.TryParse(NIK, out lastNik))
            {
                lastNik++;
            }
            else
            {
                lastNik = 111111;
            }

            return lastNik.ToString("D6");

        }
    }
}