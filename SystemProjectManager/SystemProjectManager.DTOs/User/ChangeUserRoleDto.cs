﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProjectManager.DTOs.User
{
    public class ChangeUserRoleDto
    {
        public int UserId { get; set; }
        public List<string> NewRoles { get; set; }
    }
}
