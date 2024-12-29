namespace budgetbuddy;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnLoginClicked(object sender, EventArgs e)
	{
		string username = await DisplayPromptAsync("Username", "What is your username?", "Submit");

		if (username.Length > 0) 
		{
			string password = await DisplayPromptAsync("Password", "What is your password", "Submit");
		}
		else 
		{
			await DisplayAlert("Error!", "Enter a username!", "Ok");
		}
	}

	private async void OnSignUpClicked(object sender, EventArgs e) 
	{
        await Navigation.PushAsync(new SignUpPage());
    }
}

