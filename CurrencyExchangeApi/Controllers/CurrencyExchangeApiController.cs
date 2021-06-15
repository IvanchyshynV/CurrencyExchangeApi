using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using CurrencyExchangeApi.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CurrencyExchangeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyExchangeApiController : ControllerBase
    {


        private readonly ILogger<CurrencyExchangeApiController> _logger;
        private readonly CurrencyClient _currencyClient;
        private readonly IDynamoDbClient _dynamoDbClient;
       
        public CurrencyExchangeApiController(ILogger<CurrencyExchangeApiController> logger, CurrencyClient currencyClient,IDynamoDbClient dynamoDbClient)
        {
            _logger = logger;
            _currencyClient = currencyClient;
            _dynamoDbClient = dynamoDbClient;
        }
        [HttpGet("convert")]
        public async Task<ApiResponse> ConvertCurrency([FromQuery] CurrencyParams parameters)
        {

            var currency = await _currencyClient.ConvertCurrency(parameters.From, parameters.To, parameters.Amount);
            var result = new ApiResponse
            {
                Date = currency.Response.Date,
                From = currency.Response.From,
                To = currency.Response.To,
                Amount = currency.Response.Amount.ToString(),
                Value = currency.Response.Value.ToString()
            };
            return result;
        }
        
        [HttpGet("NamesAndCountries")]
        public async Task<CurrenciesNames> GetNamesAndCountries()
        {
            var currency = await _currencyClient.GetNamesAndCountries();
            var result = new CurrenciesNames
            {
                AED = currency.Response.Fiats.AED,
                AFN = currency.Response.Fiats.AFN,
                ALL = currency.Response.Fiats.ALL,
                AMD = currency.Response.Fiats.AMD,
                ANG = currency.Response.Fiats.ANG,
                AOA = currency.Response.Fiats.AOA,
                ARS = currency.Response.Fiats.ARS,
                AUD = currency.Response.Fiats.AUD,
                AWG = currency.Response.Fiats.AWG,
                AZN = currency.Response.Fiats.AZN,
                BAM = currency.Response.Fiats.BAM,
                BBD = currency.Response.Fiats.BBD,
                BDT = currency.Response.Fiats.BDT,
                BGN = currency.Response.Fiats.BGN,
                BHD = currency.Response.Fiats.BHD,
                BIF = currency.Response.Fiats.BIF,
                BMD = currency.Response.Fiats.BMD,
                BND = currency.Response.Fiats.BND,
                BOB = currency.Response.Fiats.BOB,
                BRL = currency.Response.Fiats.BRL,
                BSD = currency.Response.Fiats.BSD,
                BTN = currency.Response.Fiats.BTN,
                BWP = currency.Response.Fiats.BWP,
                BYN = currency.Response.Fiats.BYN,
                BZD = currency.Response.Fiats.BZD,
                CAD = currency.Response.Fiats.CAD,
                CDF = currency.Response.Fiats.CDF,
                CHF = currency.Response.Fiats.CHF,
                CLF = currency.Response.Fiats.CLF,
                CLP = currency.Response.Fiats.CLP,
                CNY = currency.Response.Fiats.CNY,
                COP = currency.Response.Fiats.COP,
                CRC = currency.Response.Fiats.CRC,
                CUC = currency.Response.Fiats.CUC,
                CUP = currency.Response.Fiats.CUP,
                CVE = currency.Response.Fiats.CVE,
                CZK = currency.Response.Fiats.CZK,
                DJF = currency.Response.Fiats.DJF,
                DKK = currency.Response.Fiats.DKK,
                DOP = currency.Response.Fiats.DOP,
                DZD = currency.Response.Fiats.DZD,
                EGP = currency.Response.Fiats.EGP,
                ERN = currency.Response.Fiats.ERN,
                ETB = currency.Response.Fiats.ETB,
                EUR = currency.Response.Fiats.EUR,
                FJD = currency.Response.Fiats.FJD,
                FKP = currency.Response.Fiats.FKP,
                GBP = currency.Response.Fiats.GBP,
                GEL = currency.Response.Fiats.GEL,
                GHS = currency.Response.Fiats.GHS,
                GIP = currency.Response.Fiats.GIP,
                GMD= currency.Response.Fiats.GMD,
                GNF = currency.Response.Fiats.GNF,
                GTQ = currency.Response.Fiats.GTQ,
                GYD = currency.Response.Fiats.GYD,
                HKD= currency.Response.Fiats.HKD,
                HNL = currency.Response.Fiats.HNL,
                HRK = currency.Response.Fiats.HRK,
                HUF = currency.Response.Fiats.HUF,
                IDR = currency.Response.Fiats.IDR,
                ILS = currency.Response.Fiats.ILS,
                INR = currency.Response.Fiats.INR,
                IQD = currency.Response.Fiats.IQD,
                IRR = currency.Response.Fiats.IRR,
                ISK = currency.Response.Fiats.ISK,
                JMD = currency.Response.Fiats.JMD,
                JOD = currency.Response.Fiats.JOD,
                JPY = currency.Response.Fiats.JPY,
                KES = currency.Response.Fiats.KES,
                KGS = currency.Response.Fiats.KGS,
                KHR = currency.Response.Fiats.KHR,
                KMF = currency.Response.Fiats.KMF,
                KPW = currency.Response.Fiats.KPW,
                KRW = currency.Response.Fiats.KRW,
                KWD = currency.Response.Fiats.KWD,
                KZT = currency.Response.Fiats.KZT,
                LAK = currency.Response.Fiats.LAK,
                LBP = currency.Response.Fiats.LBP,
                LKR = currency.Response.Fiats.LKR,
                LRD = currency.Response.Fiats.LRD,
                LSL = currency.Response.Fiats.LSL,
                LYD = currency.Response.Fiats.LYD,
                MAD = currency.Response.Fiats.MAD,
                MDL = currency.Response.Fiats.MDL,
                MGA = currency.Response.Fiats.MGA,
                MKD = currency.Response.Fiats.MKD,
                MMK = currency.Response.Fiats.MMK,
                MNT = currency.Response.Fiats.MNT,
                MOP = currency.Response.Fiats.MOP,
                MRU = currency.Response.Fiats.MRU,
                MUR = currency.Response.Fiats.MUR,
                MVR = currency.Response.Fiats.MVR,
                MWK = currency.Response.Fiats.MWK,
                MXN = currency.Response.Fiats.MXN,
                MXV = currency.Response.Fiats.MXV,
                MYR = currency.Response.Fiats.MYR,
                MZN = currency.Response.Fiats.MZN,
                NAD = currency.Response.Fiats.NAD,
                NGN = currency.Response.Fiats.NGN,
                NIO = currency.Response.Fiats.NIO,
                NOK = currency.Response.Fiats.NOK,
                NPR = currency.Response.Fiats.NPR,
                NZD = currency.Response.Fiats.NZD,
                OMR = currency.Response.Fiats.OMR,
                PAB = currency.Response.Fiats.PAB,
                PEN = currency.Response.Fiats.PEN,
                PGK = currency.Response.Fiats.PGK,
                PHP = currency.Response.Fiats.PHP,
                PKR = currency.Response.Fiats.PKR,
                PLN = currency.Response.Fiats.PLN,
                PYG = currency.Response.Fiats.PYG,
                QAR = currency.Response.Fiats.QAR,
                RON = currency.Response.Fiats.RON,
                RSD = currency.Response.Fiats.RSD,
                RUB = currency.Response.Fiats.RUB,
                RWF = currency.Response.Fiats.RWF,
                SAR = currency.Response.Fiats.SAR,
                SBD = currency.Response.Fiats.SBD,
                SCR = currency.Response.Fiats.SCR,
                SDG = currency.Response.Fiats.SDG,
                SEK = currency.Response.Fiats.SEK,
                SHP = currency.Response.Fiats.SHP,
                SLL = currency.Response.Fiats.SLL,
                SOS = currency.Response.Fiats.SOS,
                SRD = currency.Response.Fiats.SRD,
                STN = currency.Response.Fiats.STN,
                SVC = currency.Response.Fiats.SVC,
                SYP = currency.Response.Fiats.SYP,
                SZL = currency.Response.Fiats.SZL,
                THB = currency.Response.Fiats.THB,
                TJS = currency.Response.Fiats.TJS,
                TMT = currency.Response.Fiats.TMT,
                TND = currency.Response.Fiats.TND,
                TOP = currency.Response.Fiats.TOP,
                TRY = currency.Response.Fiats.TRY,
                TTD = currency.Response.Fiats.TTD,
                TWD = currency.Response.Fiats.TWD,
                TZS = currency.Response.Fiats.TZS,
                UAH = currency.Response.Fiats.UAH,
                UGX = currency.Response.Fiats.UGX,
                USD = currency.Response.Fiats.USD,
                UYU = currency.Response.Fiats.UYU,
                UZS = currency.Response.Fiats.UZS,
                VES = currency.Response.Fiats.VES,
                VND = currency.Response.Fiats.VND,
                VUV = currency.Response.Fiats.VUV,
                WST = currency.Response.Fiats.WST,
                XAF = currency.Response.Fiats.XAF,
                XAG = currency.Response.Fiats.XAG,
                XAU = currency.Response.Fiats.XAU,
                XCD = currency.Response.Fiats.XCD,
                XDR = currency.Response.Fiats.XDR,
                XOF = currency.Response.Fiats.XOF,
                XPD = currency.Response.Fiats.XPD,
                XPF = currency.Response.Fiats.XPF,
                XPT = currency.Response.Fiats.XPT,
                YER = currency.Response.Fiats.YER,
                ZAR = currency.Response.Fiats.ZAR,
                ZMW = currency.Response.Fiats.ZMW
            };
            return result;
        }
        [HttpGet("getconverted")]
        public async Task<DbResponse> ConvertCurrencies([FromQuery] DbParameters parameters)
        {
            var response = await _dynamoDbClient.ConvertCurrencies(parameters.Currency);
            if (response == null)
                return null;
            var result = new DbResponse
            {
                Currency=response.Currency,
                Date=response.Date,
                Amount = response.Amount,
                From =response.From,
                To=response.To,
                Value=response.Value
            };
            return result;
        }
        [HttpPost("addconverted")]
        public async Task<IActionResult> AddConvertedValues([FromBody] DbResponse response,[FromQuery] DbParameters parameters )
        {
            var data = new ConvertDbRepository
            {
                Currency=parameters.Currency,
                Date=response.Date,
                From = response.From,
                To = response.To,
                Amount = response.Amount,
                Value = response.Value
            };
            var result = await _dynamoDbClient.PostDataToDb(data);
            if(result==false)
            {
                return BadRequest("Can`t insert value to DB. Please see concole log.");
            }
           return Ok("Data has been successfully added.");
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _dynamoDbClient.GetAll();
            if (response == null)
                return NotFound("There are no data in DB");
            var result = response.Select(x => new ApiResponse()
            {
                Date = x.Date,
                From = x.From,
                Amount = x.Amount,
                To = x.To,
                Value=x.Value
            }).ToList();
            return Ok(result);
        }
        
    }
}
