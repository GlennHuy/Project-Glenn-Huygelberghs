namespace ConsoleMusicPlayer
{
    public class FrontEnd
    {
        public void PrintTitle()
        {
            Console.WriteLine("MEDIAPLAYER");
            Console.WriteLine("Enter the path to a song.");
        }
        public void PrintMenu()
        {
            Console.WriteLine("1 to pause or play \\ 2 to stop \\ 3 to change volume \\ 4 to mute/unmute \\ 5 to put on a new song \\ 0 to quit");
        }
    }
}