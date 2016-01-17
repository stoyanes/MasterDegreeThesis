using Server.Data.Model;
using System.Collections.Generic;

namespace Server.Business.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public EmployeeDto Manager { get; set; }
    }
}
