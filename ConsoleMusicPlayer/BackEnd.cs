using WMPLib;

namespace ConsoleMusicPlayer
{
    public class BackEnd
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public string GetUserChoice()
        {
            string input = TrimInput(Console.ReadLine());
            return input;
        }
        private string TrimInput(string input)
        {
            string trimmedChoice = input.Trim('"');
            return trimmedChoice;
        }
        public void Initialize(string input)
        {
            string musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            player.URL = Path.Combine(musicFolder, input);
            player.controls.play();
        }
        public bool PausePlay(bool input)
        {
            bool songPlaying = input;
            switch (songPlaying)
            {
                case true:
                    songPlaying = false;
                    player.controls.pause();
                    break;
                case false:
                    songPlaying = true;
                    player.controls.play();
                    break;
                default:
                    break;
            }
            return songPlaying;
        }
        public void MuteUnmute(bool songStatus)
        {
            bool songPlaying = songStatus;
            if (songPlaying == true && player.settings.mute != true)
            {
                player.settings.mute = true;
            }
            else if (songPlaying == true && player.settings.mute == true)
            {
                player.settings.mute = false;
            }
        }
    }
}
