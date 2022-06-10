using WMPLib;

namespace ConsoleMusicPlayer
{
    public class BackEnd
    {
        WindowsMediaPlayer _player;
        public BackEnd(WindowsMediaPlayer player)
        {
           _player = player;
        }
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
            _player.URL = Path.Combine(musicFolder, input);
            _player.controls.play();
        }
        public bool PausePlay(bool input)
        {
            bool songPlaying = input;
            switch (songPlaying)
            {
                case true:
                    songPlaying = false;
                    _player.controls.pause();
                    return songPlaying;
                case false:
                    songPlaying = true;
                    _player.controls.play();
                    return songPlaying;
                default:

            }
        }
        public void MuteUnmute(bool songStatus)
        {
            bool songPlaying = songStatus;
            if (songPlaying == true && _player.settings.mute != true)
            {
                _player.settings.mute = true;
            }
            else if (songPlaying == true && _player.settings.mute == true)
            {
                _player.settings.mute = false;
            }
        }
        public int GetVolume()
        {
            int volume = Convert.ToInt32(Console.ReadLine());
            return volume;
        }

        public void Volume(bool songStatus, int volume)
        {
            if (songStatus == true)
            {
                _player.settings.volume = volume;
            }
            if (songStatus != true)
            {
                Console.WriteLine("");
            }
        }
        public void StopPlaying()
        {
            _player.controls.stop();
        }
        public void HandleUserInput(int userChoice)
        {

        }
    }
}
