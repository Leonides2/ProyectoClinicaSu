using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Email
{
    public interface ISvEmail
    {
        public void SendEmail(string to, string subject, string message, GmailSettings settings);
    }
}
