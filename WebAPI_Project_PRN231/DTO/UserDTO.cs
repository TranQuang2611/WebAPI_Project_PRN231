﻿namespace WebAPI_Project_PRN231.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}