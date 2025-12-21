using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.BusinessLogic.DTOs.Departments
{
    public class UpdatedDepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;

        public string? Description { get; set; }
        public DateOnly DateOfCreation
        {
            get; set;


        }
    }
}
