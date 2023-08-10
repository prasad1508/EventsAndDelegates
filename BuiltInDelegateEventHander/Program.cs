namespace BuiltInDelegateEventHander
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var video = new Video();
            var videoEncorder = new VideoEncorder(); // Publisher

            var mailService = new MailService();// Subscriber
            var messageService = new MessageService();// Subscriber

            videoEncorder.VideoEncoded += mailService.OnVideoEncoded; // This is how we subscribe
            videoEncorder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncorder.Encode(video);
        }
    }

    //Subscriber
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args) // Handler
        {
            Console.WriteLine("Mail Service2 : Sending email... " + args.Video.Title);
        }
    }


    //Subscriber
    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args) // Handler
        {
            Console.WriteLine("Message Service2 : Sending message... " + args.Video.Title);
        }
    }

}