using Microsoft.AspNetCore.Components;
using ReportWebApp.Services;

namespace ReportWebApp.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Inject]
        protected LoginService LoginService { get; set; }

        protected void Logout()
        {

            if (LoginService != null && Navigation != null)
            {
                LoginService.Logout();
                Navigation.NavigateTo("/login", true);
            }
        }
    }
}
