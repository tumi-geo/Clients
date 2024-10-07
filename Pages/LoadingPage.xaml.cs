using Client.Services;

namespace Client.Pages;

public partial class LoadingPage : ContentPage
{
	private readonly AuthService _authService;
	public LoadingPage(AuthService authService)
	{
		InitializeComponent();
		_authService = authService;
	}

	protected async override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		if (await _authService.IsAuthenticatedAsync())
		{
			//User is logged in
			//directed to main page
			await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
		}
		else
		{
			//User is not logged in
			await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
		}
	}
}