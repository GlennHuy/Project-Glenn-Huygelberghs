using WMPLib;

namespace ConsoleMusicPlayer
{
    public class BackEnd
    {
        public string GetUserChoice()
        {
            Console.WriteLine("Enter path to song file.");
            string input = TrimInput(Console.ReadLine());
            return input;
        }
        private string TrimInput(string input)
        {
            string trimmedChoice = input.Trim('"');
            return trimmedChoice;
        }
        public void PausePlay(string input)
        {
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            bool songPlaying = true;
            string control = input;
            while (control == "s" || control == "p") ;
            {
                switch (control)
                {
                    case "s":
                        player.controls.stop();
                        break;
                    case "p":
                        if (songPlaying == true)
                        {
                            songPlaying = false;
                            player.controls.pause();
                        }
                        else if (songPlaying == false)
                        {
                            songPlaying = true;
                            player.controls.play();
                        }
                        break;
                    default:
                        Console.WriteLine($"Enter a valid command. s to stop p to pause and play.");
                        break;
                }
                control = Console.ReadLine();
            } 
        }
    }
}
