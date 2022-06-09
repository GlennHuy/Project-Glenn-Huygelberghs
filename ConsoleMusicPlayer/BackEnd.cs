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
            bool songStatus = true;
            string control = input;
            do
            {
                switch (control)
                {
                    case "s":
                        player.controls.stop();
                        break;
                    case "p":
                        if (songStatus == true)
                        {
                            songStatus = false;
                            player.controls.pause();
                        }
                        else if (songStatus == false)
                        {
                            songStatus = true;
                            player.controls.play();
                        }
                        break;
                    default:
                        Console.WriteLine($"Enter a valid command. s to stop p to pause and play.");
                        break;
                }
            } while (control == "s" || control == "p");
        }
    }
}
