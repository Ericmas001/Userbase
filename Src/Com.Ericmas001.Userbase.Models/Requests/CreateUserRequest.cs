﻿namespace Com.Ericmas001.Userbase.Models.Requests
{
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public AuthenticationInfo Authentication { get; set; }
        public ProfileInfo Profile { get; set; }
    }
}
