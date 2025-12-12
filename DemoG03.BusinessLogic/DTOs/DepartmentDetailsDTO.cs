using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.BusinessLogic.DTOs
{
    public class DepartmentDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; } = string.Empty;

        public int CreatedBy { get; set; }
        public DateOnly DateOfCreation { get; set; }
        public int LastModifiedBy { get; set; }
       
        public bool IsDeleted { get; set; }
    }
}
