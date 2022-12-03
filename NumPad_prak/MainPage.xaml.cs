namespace NumPad_prak;

public partial class MainPage : ContentPage
{
  private const string PASSWORD = "1234567";
  private bool _ignoreClicks = false;

	public MainPage()
	{
		InitializeComponent();
	}

  private void DigitClicked(object sender, EventArgs e)
  {
    if (!_ignoreClicks)
		DisplayLabel.Text += (sender as Button).Text;
  }

  private void ClearClicked(object sender, EventArgs e)
  {
	if (!_ignoreClicks)
      DisplayLabel.Text = "";
  }

  private void CheckClicked(object sender, EventArgs e)
  {

	if (DisplayLabel.Text == PASSWORD)
	{
	  var a = GridMain.Children;
      DisplayLabel.Text = "You are right";

	  foreach (var b in a.Cast<View>())
	  {
		b.IsEnabled = false;
	  }

	  //_ignoreClicks = true;
	}
	else
	{
	  ClearClicked(sender, e);
	}
	  
  }

}

