using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Consummer.Model.Brevo;

namespace Consummer.Model.Config
{
    public class SmtpEmailModel
	{
		public SmtpEmailModel()
		{

		}
		public SmtpEmailModel(SenderModel sender, List<ToModel> to, string htmlContent, string subject = null, List<BccModel> bcc = null, List<CcModel> cc = null, ReplyTo replyTo = null, List<string> tags = null)
		{
			Sender = sender;
			To = to;
			HtmlContent = htmlContent;
			Subject = subject;
			ReplyTo = replyTo;
			Tags = tags;
			Bcc = bcc;
			Cc = cc;
		}

		[JsonPropertyName("sender")]
		public SenderModel Sender { get; set; }
		[JsonPropertyName("to")]
		public List<ToModel> To { get; set; }
		[JsonPropertyName("bcc")]
		public List<BccModel> Bcc { get; set; }
		[JsonPropertyName("cc")]
		public List<CcModel> Cc { get; set; }
		[JsonPropertyName("htmlContent")]
		public string HtmlContent { get; set; }
		[JsonPropertyName("subject")]
		public string Subject { get; set; }
		[JsonPropertyName("replyTo")]
		public ReplyTo ReplyTo { get; set; }
		[JsonPropertyName("tags")]
		public List<string> Tags { get; set; }
	}
}

