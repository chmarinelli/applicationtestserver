using System.Collections.Generic;
using TestServer.DM.Entities;

namespace TestServer.DM.SampleData
{
    public class PermitTypeSample
    {
        private static List<PermitType> _permissionTypes;

        static PermitTypeSample()
        {
            if (_permissionTypes == null)
            {
                PermitsTypes = new List<PermitType>()
                {
                    new PermitType { Description = "Enfermedad" },
                    new PermitType { Description = "Diligencias" },
                    new PermitType { Description = "Otros" },
                };
            }
        }
        public static List<PermitType> PermitsTypes { get => _permissionTypes; set => _permissionTypes = value; }

    }
}
