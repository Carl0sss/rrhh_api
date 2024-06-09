namespace rrhh_api.Dto
{
    public class AuthResponse
    {
        public string token {  get; set; }
        public string refreshToken { get; set; }
        public bool result { get; set; }
        public string message { get; set; }

    }
}
