public class CountryInfoForm : Form
{
    private TextBox _countryInputTextBox = new TextBox();
    private TextBox _resultTextBox = new TextBox();
    private Button _searchButton = new Button();
    private Label _inputLabel = new Label();

    private readonly CountryInfoService _countryInfoService;

    public CountryInfoForm()
    {
        _countryInfoService = new CountryInfoService();
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Text = "Country Info Fetcher";
        this.Size = new Size(550, 450);

        _inputLabel.Text = "Enter Country Name:";
        _inputLabel.Location = new Point(12, 15);
        _inputLabel.AutoSize = true;

        _countryInputTextBox.Location = new Point(170, 12);
        _countryInputTextBox.Size = new Size(200, 23);

        _searchButton.Text = "Search";
        _searchButton.Location = new Point(400, 10);
        _searchButton.Size = new Size(120, 27);
        _searchButton.Click += SearchButton_Click!;

        _resultTextBox.Location = new Point(12, 50);
        _resultTextBox.Size = new Size(460, 320);
        _resultTextBox.Multiline = true;
        _resultTextBox.ScrollBars = ScrollBars.Vertical;
        _resultTextBox.ReadOnly = true;
        _resultTextBox.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);

        this.Controls.Add(_inputLabel);
        this.Controls.Add(_countryInputTextBox);
        this.Controls.Add(_searchButton);
        this.Controls.Add(_resultTextBox);
    }

    private async void SearchButton_Click(object sender, EventArgs e)
    {
        string countryName = _countryInputTextBox.Text;
        if (string.IsNullOrWhiteSpace(countryName))
        {
            MessageBox.Show("Please enter a country name.");
            return;
        }

        _searchButton.Enabled = false;
        _resultTextBox.Clear();

        try
        {
            string? content = await _countryInfoService.GetContentAsync(countryName);
            _resultTextBox.Text = content ?? $"No information found for '{countryName}'.";
        }
        catch (Exception ex)
        {
            _resultTextBox.Text = $"An error occurred: {ex.Message}";
        }
        finally
        {
            _searchButton.Enabled = true;
        }
    }
}
