﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogProjectMVC.Services
{
   public interface IBlogEmailSender: IEmailSender
    {
        Task SendContactEmailAsync(string eamilFrom, string name, string subject, string htmlMessage);
    }
}
