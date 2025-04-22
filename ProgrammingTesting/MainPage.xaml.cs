using ProgrammingTesting.Pages;
using ProgrammingTesting.Singletons;

namespace ProgrammingTesting
{
    public partial class MainPage : ContentPage
    {
        private IServiceProvider _serviceProvider;

        public MainPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            this.OnFocusRereshScore();
        }

        private void OnFocusRereshScore() =>
            this.Focused += (_, _) => scoreLabel.Text = $"Score - {Score.Value.ToString()}";

        private async void OnStartTest(object sender, EventArgs e)
        {
            //service locator
            TestUnitworkPage testUnitworkPage = _serviceProvider.GetRequiredService<TestUnitworkPage>();
            await Shell.Current.Navigation.PushModalAsync(testUnitworkPage);
            
            SemanticScreenReader.Announce(beginTestButton.Text);
        }
    }

}
