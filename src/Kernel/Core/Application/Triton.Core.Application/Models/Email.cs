namespace Triton.Core.Application.Models
{
    public class Email
    {
        public Email()
        {
            To = string.Empty;
            Subject = string.Empty;
            Body = string.Empty;
        }

        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
