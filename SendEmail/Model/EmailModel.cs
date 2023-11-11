namespace SendEmail.Model
{
    public class EmailModel
    {
        public int Id { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }

        //colocar ForeignKey para EmailReceiverModel
        public string EmailSender { get; set; }

        public string EmailReceiver { get; set; }

        public string EmailPassword { get; set; }
  
    }
}
