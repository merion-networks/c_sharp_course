using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProjectManager.DTOs.Project
{
    public class AddProjectMemberDto
    {
        public int UserId { get; set; }
        public string RoleInProject { get; set; }
    }
}
