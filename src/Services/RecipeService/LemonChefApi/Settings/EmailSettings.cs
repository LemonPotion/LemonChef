namespace LemonChefApi.Settings;

public class EmailSettings
{
    public string SmtpServer { get; set; }
    public int Port { get; set; }
    public string From { get; set; }
    public string Password { get;set; }
    
    public bool EnableSsl { get; set; }
}