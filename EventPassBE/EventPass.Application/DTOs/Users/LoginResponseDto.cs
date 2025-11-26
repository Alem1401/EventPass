namespace EventPass.Application.DTOs.Users
{
    public class LoginResponseDto
    {
        public string jwtToken { get; set; }
        public string refreshToken { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }
}
