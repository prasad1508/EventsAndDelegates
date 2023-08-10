namespace SimpleEventAndDelegateProject
{
    public class VideoEncorder
    {
        // When publishing events 3 steps need to follow
        //1 - Define a delegate (Contract beween publisher and subscriber)
        //    Define a delegate which hold the reference to function looks like => void VideoEncodedEventHandler(object source,EventArgs args);
        //2 - Define an event, based on that delegate
        //3 - Raise the event (we need a method that responsible for raising events)
        

        //1 - Define a delegate - which determine shape/signature of the method in subscriber
        // source: class that is sending the event
        // Args: Additional data we need to pass with event
        public delegate void VideoEncodedEventHandler(object source,EventArgs args);

        //2 - Define/Create an event based on that delegate (VideoEncodedEventHandler)
        // Use past tense for event naming convention (some thing has happend or finished) => VideoEncorded
        // Sometime we use present tense (VideoEncording) that case, that event should fired/publish before the encording is started
        // When video is encoded this event published and say to subscribers video has been encoded.
        // VideoEncoded is hold the list of pointers to methods behind the scenes
        // C# events/delegates are multicast, so the delegate is itself a list.
        public event VideoEncodedEventHandler VideoEncoded; // Event

        public void Encode(Video video)
        {
            Console.WriteLine("Encording Video1... wait 2 sec");
            Thread.Sleep(2000);

            //3 - Raise the event
            OnVideoEncoded(); // This method will notify to all the subscribers 
        }


        //  Event publisher method should be protected, virtual, and void
        //  Naming convention start with "On" + "Name of the event"
        protected virtual void OnVideoEncoded() // This is the Event publisher method
        {
            // Check is there any subscribers, not null means we have subscribers
            // To see whats inside open immediate window and type VideoEncoded.GetInvocationList().Count()
            if (VideoEncoded != null)
            {
                // first param is source, this =>  who is publish the event, Answer is current class (VideoEncorder) , so we use this keyword
                VideoEncoded(this, EventArgs.Empty);
            }
        }

    }
}