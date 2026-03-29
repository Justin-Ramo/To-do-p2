using Microsoft.Extensions.DependencyInjection;

namespace todo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

          
            SignInPage signInPage = new SignInPage();   

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}