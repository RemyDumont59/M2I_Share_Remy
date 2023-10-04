namespace Quiz.Views;

public partial class Q11 : ContentPage
{
	public Q11()
	{
		InitializeComponent();
	}


    public async void Loose(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

}