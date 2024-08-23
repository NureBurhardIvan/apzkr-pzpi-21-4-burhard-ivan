namespace Application.Common.Options;

public class AwsOptions
{
    public string SecretKey { get; set; } = string.Empty;
    public string AccessKey { get; set; } = string.Empty;
    public string UserPoolId { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string UserPoolClientId { get; set; } = string.Empty;
}