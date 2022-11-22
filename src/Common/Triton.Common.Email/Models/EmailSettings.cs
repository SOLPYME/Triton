namespace Triton.Common.EMail.Models
{
    public class EmailSettings
    {
        public EmailSettings()
        {
            ApiKey = string.Empty;
            FromAddress = string.Empty;
            FromName = string.Empty;
        }

        public string ApiKey { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
