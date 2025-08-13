public class CatFactsForm : Form
{
    private Button _getFactButton = new Button();
    private Button _clearButton = new Button();
    private TextBox _responseTextBox = new TextBox();
    private readonly IApiService _catfactService;

    public CatFactsForm()
    {
        _catfactService = new CatFactsService();
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Text = "Cat Fact Fetcher";
        this.Size = new Size(500, 400);

        _getFactButton.Text = "Get a Cat Fact";
        _getFactButton.Location = new Point(12, 12);
        _getFactButton.Size = new Size(150, 30);
        _getFactButton.Click += GetJokeButton_Click!;

        _clearButton.Text = "Clear Output";
        _clearButton.Location = new Point(163, 12);
        _clearButton.Size = new Size(75, 30);
        _clearButton.Click += ClearButton_Click!;

        _responseTextBox.Location = new Point(12, 50);
        _responseTextBox.Size = new Size(460, 280);
        _responseTextBox.Multiline = true;
        _responseTextBox.ScrollBars = ScrollBars.Vertical;
        _responseTextBox.ReadOnly = true;

        this.Controls.Add(_getFactButton);
        this.Controls.Add(_responseTextBox);
        this.Controls.Add(_clearButton);
    }

    private async void GetJokeButton_Click(object sender, EventArgs e)
    {
        var currentContent = _responseTextBox.Text;
        _responseTextBox.AppendText("Fetching fact..." + Environment.NewLine);
        _responseTextBox.Text = currentContent + await _catfactService.GetContentAsync();
        _responseTextBox.AppendText(Environment.NewLine + Environment.NewLine);
    }

    private void ClearButton_Click(object sender, EventArgs e)
    {
        _responseTextBox.Text = string.Empty;
    }
}
