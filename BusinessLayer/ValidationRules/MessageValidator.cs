using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mail Text Alanını Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Geçemezsiniz");
            //RuleFor(x => x.SenderMail).NotEmpty().WithMessage("Gönderici Adını Boş Geçemezsiniz");
            RuleFor(x => x.RecieverMail).NotEmpty().WithMessage("Alıcı Adını Boş Geçemezsiniz");
            RuleFor(x => x.SenderMail).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.RecieverMail).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayın");
        }
    }
}
