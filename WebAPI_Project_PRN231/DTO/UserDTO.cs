﻿namespace WebAPI_Project_PRN231.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; } = 0;
        public string Username { get; set; } = null!;
        public string? Image { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
