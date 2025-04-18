using ProgrammingTesting.Pages;

namespace ProgrammingTesting
{
    public partial class MainPage : ContentPage
    {
        private IServiceProvider _serviceProvider;

        public MainPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private async void OnStartTest(object sender, EventArgs e)
        {
            TestUnitworkPage testUnitworkPage = _serviceProvider.GetRequiredService<TestUnitworkPage>();
            await Shell.Current.Navigation.PushModalAsync(testUnitworkPage);

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
