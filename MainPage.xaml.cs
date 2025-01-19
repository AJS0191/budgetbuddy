using MySql.Data.MySqlClient;
using System.Data.Common;

namespace budgetbuddy;

public partial class MainPage : ContentPage
{
    MySqlConnectionStringBuilder str = new MySqlConnectionStringBuilder()
    {
        Server = "database-test.cjgqe88ia68b.us-east-2.rds.amazonaws.com",
        Port = 3306,
        Database = "Tester",
        UserID = "admin",
        Password = "test1999",
        SslMode = MySqlSslMode.Disabled,
        ConnectionTimeout = 60
    };


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

			if (password.Length > 0)
			{
				try
				{
                    string connectionString = str.ConnectionString;

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        await connection.OpenAsync();
                        string query = "select * from users where username = @username and password = @password;";

						using (MySqlCommand command = new MySqlCommand(query, connection))
						{
                            command.Parameters.AddWithValue("@username", username);
                            command.Parameters.AddWithValue("@password", password);

                            using (DbDataReader reader = await command.ExecuteReaderAsync())
                            {

                                if (reader.HasRows)
								{
									await DisplayAlert("Success!", "Connection successful!", "Ok");

                                    while (await reader.ReadAsync())
                                    {
                                        string name = $"{reader.GetString(1)} {reader.GetString(2)}";
                                        await DisplayAlert("Welcome!", name, "Ok");
                                    }
                                }
								else
								{
									await DisplayAlert("Error!", "Username or password is incorrect!", "Ok");
								}
                            }
                        }
                    }
                }
				catch(Exception ex)
				{
                    await DisplayAlert("Error", ex.Message, "Ok");
                }
			}
			else
			{
				await DisplayAlert("Error!", "Enter a password!", "Ok");
			}
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

