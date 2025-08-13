public class MainMenuForm : Form
{
    private Button _dadJokeButton = new Button();
    private Button _catFactButton = new Button();
    private Button _countryInfoButton = new Button();
    private Button _exitButton = new Button();

    public MainMenuForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Text = "API Fetcher Main Menu";
        this.Size = new Size(300, 300);
        

        _dadJokeButton = new Button();
        _dadJokeButton.Text = "Dad Jokes";
        _dadJokeButton.Location = new Point(30, 30);
        _dadJokeButton.Size = new Size(220, 40);
        _dadJokeButton.Click += DadJokeFetcherButton_Click!;

        _catFactButton = new Button();
        _catFactButton.Text = "Cat Facts";
        _catFactButton.Location = new Point(30, 80);
        _catFactButton.Size = new Size(220, 40);
        _catFactButton.Click += CatFactFetcherButton_Click!;

        _countryInfoButton = new Button();
        _countryInfoButton.Text = "Country Info";
        _countryInfoButton.Location = new Point(30, 130);
        _countryInfoButton.Size = new Size(220, 40);
        _countryInfoButton.Click += CountryInfoButton_Click!;

        _exitButton = new Button();
        _exitButton.Text = "Exit";
        _exitButton.Location = new Point(30, 180);
        _exitButton.Size = new Size(220, 40);
        _exitButton.Click += ExitButton_Click!;

        this.Controls.Add(_dadJokeButton);
        this.Controls.Add(_catFactButton);
        this.Controls.Add(_countryInfoButton);
        this.Controls.Add(_exitButton);
    }

    private void DadJokeFetcherButton_Click(object sender, EventArgs e)
    {
        var dadJokeFetcherForm = new DadJokesForm();
        dadJokeFetcherForm.Show();
    }
    private void CatFactFetcherButton_Click(object sender, EventArgs e)
    {
        var catFactFetcherForm = new CatFactsForm();
        catFactFetcherForm.Show();
    }
    private void CountryInfoButton_Click(object sender, EventArgs e)
    {
        var countryInfoForm = new CountryInfoForm();
        countryInfoForm.Show();
        
    }
    private void ExitButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
