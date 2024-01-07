using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(Send send, byte[] attachment = null);
        byte[] GenerateInvoice(Send send); 
    }
}
