using ProgrammingTesting.ViewModels;

namespace ProgrammingTesting.Pages;

public partial class TestUnitworkPage : ContentPage
{
    private TestUnitworkViewModel ViewModel { get; set; }

    public TestUnitworkPage(TestUnitworkViewModel viewModel)
	{
		InitializeComponent();
		ViewModel = viewModel;
		BindingContext = viewModel;
    }

    private async void AnswerQuestion(object sender, EventArgs e)
    {
		//guard clause
		if (ViewModel.SelectedAnswer is null)
			return;

        ViewModel.AddCurrentAnsweredTestToAnseredCollection();
        Boolean isExistQuestions = ViewModel.NextTestUnitwork();

		if (!isExistQuestions)
		{
            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}