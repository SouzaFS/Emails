namespace SendEmail.DTOs
{
    public class EmailDTO
    {
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }

        //colocar ForeignKey para EmailReceiverModel
        public string EmailSender { get; set; }
    }
}
