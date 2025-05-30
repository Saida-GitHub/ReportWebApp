namespace ReportWebApp.Pages
{
    public partial class Login
    {
        private string username;
        private string password;
        private string errorMessage;

        public Login()
        {

        }

        public async Task HandleLogin()
        {
            if (username == "admin" && password == "password")
            {
                LoginService.Login();
                Navigation.NavigateTo("/");
            }
            else
            {
                errorMessage = "Invalid login credentials.";
            }
        }
    }
}
