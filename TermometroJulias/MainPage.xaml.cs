using Termometrojulias;

namespace TermometroJulias;

public partial class MainPage : ContentPage
{
	const string Url="https://api.hgbrasil.com/weather?woeid=455927&key=5aa02190";
	Resposta resposta;
	

	public MainPage()
	{
		InitializeComponent();

		PreencherTela();
		AtualizaTempo();

	}
		void PreencherTela()
		
		{
			labelTemp.Text= resposta.results.temp.ToString();
			labelSky.Text= resposta.results.description;
			labelCidade.Text= resposta.results.city;
			labelChuva.Text= resposta.results.rain.ToString();
			labelHumidade.Text= resposta.results.humidity.ToString();
			labelAmanhecer.Text= resposta.results.sunrise;
			labelAnoitecer.Text= resposta.results.sunset;
			labelForcawind.Text= resposta.results.wind_speedy.ToString();
			labelDirecaoWind.Text= resposta.results.wind_direction;
			labelMoonFase.Text= resposta.results.moon_phase;
			labelTemp.Text=resposta.results.temp.ToString();
			
		}
	async void AtualizaTempo()
	{
		try
		{
			var  httpClient= new HttpClient();
			var response= await httpClient.GetAsync(Url);
			if (response.IsSucessStatusCode)
			{
				var content= await httpClient.GetAsync(url);	
				Resposta= JsonSerializer.Deserialize<Results>(content);		
			}
		}
	   catch (Exception e)
	   {
			
	   }
	}
}

