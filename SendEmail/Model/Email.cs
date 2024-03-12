namespace SendEmail.Model
{
    public class Email
    {
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string EmailSender { get; set; }
        public string EmailReceiver { get; set; }
        public string EmailPassword { get; set; }
        public int CodeValidation { get; set; }
  
    }
}
