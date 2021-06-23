﻿using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IEmailMessageService
    {
        Task SendEmail(EmailMessage emailData);
        Task SendEmailWhAttachment(EmailMessageAttachment emailData);
    }
}
