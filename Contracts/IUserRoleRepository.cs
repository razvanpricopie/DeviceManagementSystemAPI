﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IUserRoleRepository
    {
        void CreateUserRole(int userId);
    }
}
