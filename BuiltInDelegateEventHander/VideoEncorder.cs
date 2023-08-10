namespace BuiltInDelegateEventHander
{

    public class VideoEventArgs:EventArgs
    {
        public Video  Video { get; set; }
    }

    public class VideoEncorder
    {
        // When publishing events 3 steps need to follow
        //1 - Define a delegate (Contract beween publisher and subscriber)
        //    Define a delegate which hold the reference to function looks like => void VideoEncordedEventHandler(object source,EventArgs args);
        //2 - Define an event, based on that delegate
        //3 - Raise the event (we need a method that responsible for raising events)

       // public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args); === public event EventHandler<VideoEventArgs> VideoEncoded;

        //1,2 - Define/Create an event based on that delegate (VideoEncodedEventHandler)       
        public event EventHandler<VideoEventArgs> VideoEncoded; // Event

        public void Encode(Video video)
        {
            Console.WriteLine("Encording Video 2... wait 2 sec");
            Thread.Sleep(2000);

            //3 - Raise the event
            OnVideoEncoded(video); // This method will notify to all the subscribers 
        }
       
        protected virtual void OnVideoEncoded(Video video) // This is the Event publisher method
        {
            if (VideoEncoded != null)
            {               
                VideoEncoded(this, new VideoEventArgs(){ Video = video});
            }
        }

    }
}