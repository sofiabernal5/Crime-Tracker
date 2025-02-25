namespace CrimeTrackerApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnLoginClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            messageLabel.Text = "Please enter both username and password.";
            messageLabel.TextColor = Colors.Red;
            return;
        }

        // Simple login validation (Replace with real authentication logic)
        if (username == "admin" && password == "password")
        {
            messageLabel.Text = "Login successful!";
            messageLabel.TextColor = Colors.Green;

            // Navigate to another page (Replace with your actual page)
            Navigation.PushAsync(new DashboardPage());
        }
        else
        {
            messageLabel.Text = "Invalid username or password.";
            messageLabel.TextColor = Colors.Red;
        }
    }
}