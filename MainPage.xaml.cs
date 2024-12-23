namespace budgetbuddy;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnLoginClicked(object sender, EventArgs e)
	{
		count++;
		int test = 3;

		if (count == 1)
			LoginButton.Text = $"Clicked {count} time {test}";
		else
			LoginButton.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(LoginButton.Text);
	}

	private void OnSignUpClicked(object sender, EventArgs e) 
	{
		count++;
    }
}

