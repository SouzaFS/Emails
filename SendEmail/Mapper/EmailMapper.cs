using SendEmail.DTOs;
using SendEmail.Model;

namespace SendEmail.Mapper
{
    public class EmailMapper
    {
        public object FromModelToDTO(EmailModel emailModel)
        {
            var emailDTO = new EmailDTO()
            {
                EmailBody = emailModel.EmailBody,
                EmailSender = emailModel.EmailSender,
                EmailSubject = emailModel.EmailSubject,
                EmailPassword = emailModel.EmailPassword,
                EmailReceiver = emailModel.EmailReceiver
            };
            return emailDTO;
        }

        public object FromDTOToModel(EmailDTO emailDTO)
        {
            var emailModel = new EmailModel()
            {
                EmailBody = emailDTO.EmailBody,
                EmailSender = emailDTO.EmailSender,
                EmailSubject = emailDTO.EmailSubject,
                EmailPassword = emailDTO.EmailPassword,
                EmailReceiver = emailDTO.EmailReceiver
            };
            return emailModel;
        }
    }
}
