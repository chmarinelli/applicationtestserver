using System;
using System.Collections.Generic;
using TestServer.DM.Entities;

namespace TestServer.DM.SampleData
{
    public class PermitSample
    {
        private static List<Permit> _permissions;

        static PermitSample()
        {
            if (_permissions == null)
            {
                var random = new Random();
                Permits = new List<Permit>()
                {
                    new Permit { 
                        EmployeeName = "Christian", 
                        EmployeeLastName = "Marinelli",
                        PermitTypeId = random.Next(1,3),
                        PermitDate = DateTime.Now.AddDays(random.Next(2, 9)) 
                    },
                    new Permit { 
                        EmployeeName = "Loenel", 
                        EmployeeLastName = "Martinez",
                        PermitTypeId = random.Next(1,3),
                        PermitDate = DateTime.Now.AddDays(random.Next(2, 9)) 
                    },
                    new Permit { EmployeeName = "Lidea", 
                        EmployeeLastName = "Reyes Espejo",
                        PermitTypeId = random.Next(1,3),
                        PermitDate = DateTime.Now.AddDays(random.Next(2, 9)) },
                    new Permit { EmployeeName = "Marcos", 
                        EmployeeLastName = "Oliver",
                        PermitTypeId = random.Next(1,3),
                        PermitDate = DateTime.Now.AddDays(random.Next(2, 9)) },
                };
            }
        }
        public static List<Permit> Permits { get => _permissions; set => _permissions = value; }

    }
}
