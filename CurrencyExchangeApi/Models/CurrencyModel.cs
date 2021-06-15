using System;

public class CurrencyModel
{
    public Response Response { get; set; }
}
  public class Response
  {
    public string Date { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public float Amount { get; set; }
    public float Value { get; set; }
  }  
  
