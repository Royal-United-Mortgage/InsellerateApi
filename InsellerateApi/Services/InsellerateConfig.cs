namespace InsellerateApi.Services;

public class InsellerateConfig
{
    public string BaseUrl { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string OrgId { get; set; }
    public List<LeadProviderInformation> LeadProviders { get; set; }
}

public class LeadProviderInformation
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}