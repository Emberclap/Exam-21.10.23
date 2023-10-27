using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }

        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (Capacity > Inbox.Count)
            {
                Inbox.Add(mail);
            }
        }
        public bool DeleteMail(string sender) => Inbox.Remove(Inbox.FirstOrDefault(x => x.Sender == sender));

        public int ArchiveInboxMessages()
        {
            foreach (Mail mail in Inbox)
            {
                Archive.Add(mail);
            }
            int count = Inbox.Count;
            Inbox.Clear();
            return count;
        }
        public string GetLongestMessage()
        {
            Mail longestMail = Inbox.MaxBy(x => x.Body.Length);
            return longestMail.ToString().TrimEnd();
        }
           
        public string InboxView()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Inbox:");
            foreach (var mail in Inbox)
            {
                sb.AppendLine(mail.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
