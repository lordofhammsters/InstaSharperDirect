using System;
using System.Linq;
using System.Threading.Tasks;
using InstaSharper.API.Builder;
using InstaSharper.Classes;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            Console.ReadKey();
        }

        public static async Task MainAsync(string[] args)
        {
            var api =
               new InstaApiBuilder()
                   .SetUser(new UserSessionData() { UserName = "smilik73", Password = "123qweasd" })
                   .SetRequestDelay(TimeSpan.FromSeconds(3))
                   .Build();

            var login = await api.LoginAsync();
            if (!login.Succeeded)
                throw new Exception(login.Info.Message);

            var directInbox = await api.GetDirectInboxAsync();
            if (!directInbox.Succeeded)
                throw new Exception(directInbox.Info.Message);

            var threads = directInbox.Value.Inbox.Threads;

            if (threads == null || threads.Count == 0)
                return;

            foreach (var thread in threads.Where(x => !x.IsSpam))
            {
                var th = await api.GetDirectInboxThreadAsync(thread.ThreadId);
                if (!th.Succeeded)
                    continue;

                foreach (var message in th.Value.Items)
                {
                    Console.WriteLine(message.Text);
                }
            }
        }
    }
}
