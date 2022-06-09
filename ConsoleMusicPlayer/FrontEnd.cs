namespace ConsoleMusicPlayer
{
    public class FrontEnd
    {
        public void PrintTitle()
        {
            Console.WriteLine("MEDIAPLAYER");
            Console.WriteLine("Enter the object path to a song.");
        }
        public void PrintMenu()
        {
            Console.WriteLine("Press p to pause/play, press s to stop the current song.");
            Console.WriteLine("8 raises the volume, 2 lowers the volume, 5 mutes/unmutes.");
        }
    }
}