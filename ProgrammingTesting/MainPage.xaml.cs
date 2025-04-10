using SimpleProgrammingTests.Features.Inky;
using System.Diagnostics;
using System.Reflection;

namespace ProgrammingTesting
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

       


            //var assembly = Assembly.GetExecutingAssembly();
            //var resourceName = assembly.GetManifestResourceNames();
            //var t = FileSystem.OpenAppPackageFileAsync("/Ink/Queen tale.ink");
            //var a = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "/Resources", "/Ink/Queen tale.ink");
            //String inkContent = File.ReadAllText("C:\\Users\\John\\source\\repos\\ProgrammingTesting\\ProgrammingTesting\\Resources\\Ink\\Queen tale.ink");
            //TestPlay test = new TestPlay(inkContent);
        }

        async Task<String> LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("QueenTale.ink");
            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
            var a = await LoadMauiAsset();
            Debug.WriteLine(a);
            TestPlay testPlay = new TestPlay(a);
   
            CounterBtn.Text = $"Clicked {count} times + {testPlay.Continue()}";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
