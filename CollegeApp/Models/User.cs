namespace CollegeApp.Models
{
    public class User
    {   
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class LoginResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}