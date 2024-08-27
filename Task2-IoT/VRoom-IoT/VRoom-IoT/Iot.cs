using System.Text;

namespace VRoom_IoT;

public class Iot
{
    private const string RoomId = "b7392d4e-11c6-49d3-b8e0-0a88b40375e5";
    private const string BaseUrl = "http://localhost:5120/api";
    private string _localization = "en";

    public async Task<string> SendIoTData()
    {
        using var httpClient = new HttpClient();

        Random random = new Random();

        int randomNumber = random.Next(-30, 151);
        
        var requestBody = new SendIoTDataRequestDto
        {
            RoomId = new Guid(RoomId),
            TemperatureC = randomNumber,
            TemperatureF = 0,
            Humidity = 60.5,
            TimeStamp = DateTime.UtcNow,
            OtherMetrics = ""
        };
        if(_localization == "us")
        {
            requestBody = new SendIoTDataRequestDto
            {
                RoomId = new Guid(RoomId),
                TemperatureC = 0,
                TemperatureF = randomNumber*9/5+32,
                Humidity = 60.5,
                TimeStamp = DateTime.UtcNow,
                OtherMetrics = ""
            };
        }
        

        
        var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);

       
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        try
        {
            Console.WriteLine($"Sending room data to server... " +
                              $"\n\tTemperature: {(_localization == "us" ? requestBody.TemperatureF : requestBody.TemperatureC)}" +
                              $"\n\tHumidity: {requestBody.Humidity}" +
                              $"\n\tTimeStamp: {requestBody.TimeStamp}" +
                              $"\n");
       
            var response = await httpClient.PostAsync($"{BaseUrl}/IoT/SendIoTData", content);
            
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;
            }
            else
            {
                Console.WriteLine($"SendIoTData failed. Status code: {response.StatusCode}");
                return string.Empty; 
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during SendIoTData: {ex.Message}");
            return string.Empty; 
        }
    }
    public class SendIoTDataRequestDto
    {
        public Guid RoomId { get; set; }
        public double TemperatureC { get; set; }
        public double TemperatureF { get; set; }
        public double Humidity { get; set; }
        public DateTime TimeStamp { get; set; }
        public string OtherMetrics { get; set; }
    }
}