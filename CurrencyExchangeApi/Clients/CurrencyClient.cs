using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyExchangeApi.Clients
{
	public class CurrencyClient
	{
		private HttpClient _client;
		private static string _adress;
		private static string _apiKey;
		public CurrencyClient()
		{
			_adress = Constants.adress;
			_apiKey = Constants.apiKey;
			_client = new HttpClient();
			_client.BaseAddress = new Uri(_adress);
		}
		public async Task<CurrencyModel> ConvertCurrency(string from, string to, float amount)
		{
			var response = await _client.GetAsync($"/v1/convert?api_key={_apiKey}&from={from}&to={to}&amount={amount}");
			response.EnsureSuccessStatusCode();
			var content = response.Content.ReadAsStringAsync().Result;
			var result = JsonConvert.DeserializeObject<CurrencyModel>(content);
			return result;
		}
		
		public async Task<NamesAndCountriesModel> GetNamesAndCountries()
        {
			var response = await _client.GetAsync($"/v1/currencies?api_key={_apiKey}");
			response.EnsureSuccessStatusCode();
			var content = response.Content.ReadAsStringAsync().Result;
			var result = JsonConvert.DeserializeObject<NamesAndCountriesModel>(content);
			return result;
        }
	}
	
}
