﻿namespace WebAPI_Project_PRN231.DTO
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "";
    }
}
