using System;
using System.Net;
using System.Net.Mail;

namespace POSDLL.Utilities
{
	public class Mail
	{
		private string userid = "";

		private string userpassword = "";

		private string host = "";

		private int port = 80;

		private string destination_email = "";

		private string subject = "";

		private string message = "";

		private MailPriority priority = MailPriority.Normal;

		public string DestinationEmail
		{
			get
			{
				string destinationEmail = this.destination_email;
				return destinationEmail;
			}
			set
			{
				this.destination_email = value;
			}
		}

		public MailPriority EmailPriority
		{
			get
			{
				MailPriority mailPriority = this.priority;
				return mailPriority;
			}
			set
			{
				this.priority = value;
			}
		}

		public string Host
		{
			get
			{
				string str = this.host;
				return str;
			}
			set
			{
				this.host = value;
			}
		}

		public string Message
		{
			get
			{
				string str = this.message;
				return str;
			}
			set
			{
				this.message = value;
			}
		}

		public int Port
		{
			get
			{
				int num = this.port;
				return num;
			}
			set
			{
				this.port = value;
			}
		}

		public string Subject
		{
			get
			{
				string str = this.subject;
				return str;
			}
			set
			{
				this.subject = value;
			}
		}

		public string UserId
		{
			get
			{
				string str = this.userid;
				return str;
			}
			set
			{
				this.userid = value;
			}
		}

		public string UserPassword
		{
			get
			{
				string str = this.userpassword;
				return str;
			}
			set
			{
				this.userpassword = value;
			}
		}

		public Mail()
		{
		}

		public bool Send(string prmDestinationEMail, string prmSubject, string prmMessage)
		{
			bool flag;
			try
			{
				MailMessage correo = new MailMessage();
				correo.From = new MailAddress(this.userid);
				correo.To.Add(prmDestinationEMail);
				correo.Subject = prmSubject;
				correo.Body = prmMessage;
				correo.IsBodyHtml = true;
				correo.Priority = this.priority;
				SmtpClient smtp = new SmtpClient();
				smtp.Credentials = new NetworkCredential(this.userid, this.userpassword);
				smtp.Host = this.host;
				smtp.Port = this.port;
				smtp.EnableSsl = true;
				smtp.Send(correo);
				flag = true;
			}
			catch (Exception exception)
			{
				throw exception;
			}
			return flag;
		}

		public bool Send()
		{
			bool flag;
			try
			{
				MailMessage correo = new MailMessage();
				correo.From = new MailAddress(this.userid);
				correo.To.Add(this.destination_email);
				correo.Subject = this.subject;
				correo.Body = this.message;
				correo.IsBodyHtml = true;
				correo.Priority = this.priority;
				SmtpClient smtp = new SmtpClient();
				smtp.Credentials = new NetworkCredential(this.userid, this.userpassword);
				smtp.Host = this.host;
				smtp.Port = this.port;
				smtp.EnableSsl = true;
				smtp.Send(correo);
				flag = true;
			}
			catch (Exception exception)
			{
				throw exception;
			}
			return flag;
		}
	}
}