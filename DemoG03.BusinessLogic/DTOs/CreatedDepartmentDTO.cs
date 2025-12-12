using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.BusinessLogic.DTOs
{
   public class CreatedDepartmentDTO
    {

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateOnly DateOfCreation { get; set; }

    }
}
