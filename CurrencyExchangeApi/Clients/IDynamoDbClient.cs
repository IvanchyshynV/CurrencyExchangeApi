using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDynamoDbClient
{
	public Task<ConvertDbRepository> ConvertCurrencies(string city);
	public Task<bool> PostDataToDb(ConvertDbRepository data);
	public Task Delete();
	public Task<List<ConvertDbRepository>> GetAll();
}
