namespace SimpleEventAndDelegateProject
{
    //Source:  www.youtube.com/watch?v=jQgwEsJISy0
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video();
            var videoEncorder = new VideoEncorder(); // Publisher

            var mailService = new MailService();// Subscriber
            var messageService = new MessageService();// Subscriber

            // Before we call Encode(video) method, we need to do the subscription 
            // publisher.publisherEventName
            // +=  register handler to that event
            videoEncorder.VideoEncoded += mailService.OnVideoEncoded; // This is how we subscribe, no method call, just pointer
            videoEncorder.VideoEncoded += messageService.OnVideoEncoded;
           
            videoEncorder.Encode(video);
        }
    }

    //Subscriber
    public class MailService 
    {
        // Event Handler method, this is the method signature publisher and subscriber agree upon. 
        // To subscribes to event, we need a method that confirms delegate's signature => void VideoEncodedEventHandler(object source,EventArgs args);
        // that method should be void and 2 parameters (object source,EventArgs args)
        public void OnVideoEncoded(object source, EventArgs args) // Handler
        {
            Console.WriteLine("Mail Service1 : Sending email...");
        }
    }
    

    //Subscriber
    public class MessageService 
    {
        // Event Handler method
        public void OnVideoEncoded(object source, EventArgs args) // Handler
        {
            Console.WriteLine("Message Service1 : Sending message...");
        }
    }

}