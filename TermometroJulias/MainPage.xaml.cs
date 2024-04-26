﻿using System.Text.Json;
using Termometrojulias;

namespace TermometroJulias;

public partial class MainPage : ContentPage
{
	const string Url="https://api.hgbrasil.com/weather?woeid=455927&key=5aa02190";
	Resposta resposta;
	

	public MainPage()
	{
		InitializeComponent();
		AtualizaTempo();

	}
		void PreencherTela()
		
		{
			labelTemp.Text= resposta.results.Temp.ToString();
			labelSky.Text= resposta.results.description;
			labelCidade.Text= resposta.results.city;
			labelChuva.Text= resposta.results.rain.ToString();
			labelHumidade.Text= resposta.results.humidity.ToString();
			labelAmanhecer.Text= resposta.results.sunrise;
			labelAnoitecer.Text= resposta.results.sunset;
			labelForcaVento.Text= resposta.results.wind_speedy.ToString();
			labelDirecaoVento.Text= resposta.results.wind_direction.ToString();
			labelMoonFase.Text= resposta.results.moon_phase;
			
			if (resposta.results.currently =="dia")
			{
				if (resposta.results.rain >=10)
				imagemdefundo.Source="diachuvoso.jpg";
				else if (resposta.results.cloudiness >=10)
				imagemdefundo.Source="dianublado.jpg";
				else
				imagemdefundo.Source="diaensolarado.jpg";
			}
			else
			   
			{
				if (resposta.results.rain >=10)
				imagemdefundo.Source="noitechuvosa.jpg";
				else if (resposta.results.cloudiness >=10)
				imagemdefundo.Source="noitenublada.jpg";
				else
				imagemdefundo.Source="noiteestrelada.jpg";
			}

		}
	async void AtualizaTempo()
	{
		try
		{
			var  httpClient= new HttpClient();
			var response= await httpClient.GetAsync(Url);
			if (response.IsSuccessStatusCode)
			{
				var content= await response.Content.ReadAsStringAsync();
				resposta= JsonSerializer.Deserialize<Resposta>(content);		
			}
			PreencherTela();
		}
	   catch (Exception e)
	   {
			System.Diagnostics.Debug.WriteLine(e);
	   }
	}
}

