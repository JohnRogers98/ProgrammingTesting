using System.Diagnostics;

namespace ProgrammingTesting
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState? activationState)                                       
        {
            Window window = base.CreateWindow(activationState);

            window.Created += (s, e) => Debug.WriteLine("Created event");
    
            window.Activated += (s, e) => Debug.WriteLine("Activated event");
            
            window.Deactivated += (s, e) => Debug.WriteLine("Deactivated  event");

            window.Stopped += (s, e) => Debug.WriteLine("Stopped event");
            
            window.Resumed += (s, e) => Debug.WriteLine("Resumed event");

            window.Destroying += (s, e) => Debug.WriteLine("Destroying  event");

            return window;
        }

    }
}
