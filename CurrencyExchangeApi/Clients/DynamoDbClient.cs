using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DynamoDbClient:IDynamoDbClient,IDisposable
{
    private string _tableName;
    private readonly IAmazonDynamoDB _dynamoDB;
	public DynamoDbClient(IAmazonDynamoDB dynamoDB)
	{
        _dynamoDB = dynamoDB;
        _tableName = Constants.TableName;
	}

    public async Task<ConvertDbRepository> ConvertCurrencies(string key)
    {
        var item = new GetItemRequest
        {
            TableName = _tableName,
            Key = new Dictionary<string, AttributeValue>
                {
                    { "Currency",new AttributeValue{ S=key} } 
                }
        };
        var response = await _dynamoDB.GetItemAsync(item);
        if (response.Item == null || !response.IsItemSet)
        return null;
        var result = response.Item.ToClass<ConvertDbRepository>();
        return result;
        ;
    }

    public Task Delete()
    {
        throw new NotImplementedException();
    }
    public async Task <List<ConvertDbRepository>>GetAll()
    {
        var result =new List<ConvertDbRepository>();
        var request = new ScanRequest
        {
            TableName = _tableName
        };
        var response = await _dynamoDB.ScanAsync(request);
        if (response.Items == null || response.Count == 0)
            return null;
        foreach (Dictionary<string, AttributeValue> item in response.Items)
        {
            result.Add(item.ToClass<ConvertDbRepository> ());
        }
        return result;
    }

    public async Task<bool> PostDataToDb(ConvertDbRepository data)
    {
        var request = new PutItemRequest
        {
            TableName = _tableName,
            Item = new Dictionary<string, AttributeValue>
            {
                {"Currency", new AttributeValue{ S =data.Currency } },
                {"Date", new AttributeValue{ S =data.Date } },
                {"From", new AttributeValue{ S =data.From } },
                {"To", new AttributeValue{ S =data.To} },
                {"Amount", new AttributeValue{ S =data.Amount } },
                {"Value", new AttributeValue{ S =data.Value } }
            }
        };
        try
        {
            var response = await _dynamoDB.PutItemAsync(request);
            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
        catch(Exception e)
        {
            Console.WriteLine("Error\n"+e);
            return false;
        }
       
        
    }

    public void Dispose()
    {
        _dynamoDB.Dispose();
    }
}
