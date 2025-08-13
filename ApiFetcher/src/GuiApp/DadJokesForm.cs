public class DadJokesForm : Form
{
    private Button _getJokeButton = new Button();
    private Button _clearButton = new Button();
    private TextBox _responseTextBox = new TextBox();
    private readonly IApiService _dadJokeService;

    public DadJokesForm()
    {
        _dadJokeService = new DadJokesService();
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Text = "Dad Joke Fetcher";
        this.Size = new Size(500, 400);

        _getJokeButton.Text = "Get a Dad Joke";
        _getJokeButton.Location = new Point(12, 12);
        _getJokeButton.Size = new Size(150, 30);
        _getJokeButton.Click += GetJokeButton_Click!;

        _clearButton.Text = "Clear Output";
        _clearButton.Location = new Point(163, 12);
        _clearButton.Size = new Size(75, 30);
        _clearButton.Click += ClearButton_Click!;

        _responseTextBox.Location = new Point(12, 50);
        _responseTextBox.Size = new Size(460, 280);
        _responseTextBox.Multiline = true;
        _responseTextBox.ScrollBars = ScrollBars.Vertical;
        _responseTextBox.ReadOnly = true;

        this.Controls.Add(_getJokeButton);
        this.Controls.Add(_responseTextBox);
        this.Controls.Add(_clearButton);
    }

    private async void GetJokeButton_Click(object sender, EventArgs e)
    {
        var currentContent = _responseTextBox.Text;
        _responseTextBox.AppendText("Fetching joke..." + Environment.NewLine);
        _responseTextBox.Text = currentContent + await _dadJokeService.GetContentAsync();
        _responseTextBox.AppendText(Environment.NewLine + Environment.NewLine);
    }

    private void ClearButton_Click(object sender, EventArgs e)
    {
        _responseTextBox.Text = string.Empty;
    }
}
