namespace SendEmail.Model
{
    public class Email
    {
        public string EmailSubject { get; set; } = string.Empty;
        public string EmailBody { get; set; } = string.Empty;
        public string EmailSender { get; set; } = string.Empty;
        public string EmailReceiver { get; set; } = string.Empty;
        public string EmailPassword { get; set; } = string.Empty;
        public int CodeValidation { get; set; }
  
    }
}
