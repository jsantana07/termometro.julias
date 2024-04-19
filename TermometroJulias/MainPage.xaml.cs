using Termometrojulias;

namespace TermometroJulias;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();

		Resultados = new results();
		PreencherTela();

	}
		void PreencherTela()
		{
			labelTemp.Text= Resultados.temp.ToString();
			labelSky.Text= Resultados.description;
			labelCidade.Text= Resultados.city;
			labelChuva.Text= Resultados.rain.ToString();
			labelHumidade.Text= Resultados.humidity.ToString();
			labelAmanhecer.Text= Resultados.sunrise;
			labelAnoitecer.Text= Resultados.sunset;
			labelForcawind.Text= Resultados.wind_speedy.ToString();
			labelDirecaoWind.Text= Resultados.wind_direction;
			labelMoonFase.Text= Resultados.moon_phase;


		}
	
}

