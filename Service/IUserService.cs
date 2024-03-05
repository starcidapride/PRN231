﻿using BussinessObjects;
using Service.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        public User Login(string email, string password);
        public RegisterDto AddUser(RegisterDto registerDto);
    }
}
