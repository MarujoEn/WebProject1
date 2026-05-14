namespace WebProject1.Models
{
    public class LoginViewModel
    {
        //Encapsulamento - modificadores get; set;
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public string UserLevel { get; set; } = "user";
    }
}
