using WMPLib;

namespace ConsoleMusicPlayer
{
    public class BackEnd
    {
        private WindowsMediaPlayer _player;
        private FrontEnd _frontEnd;

        public BackEnd(WindowsMediaPlayer player, FrontEnd frontEnd)
        {
            _player = player;
            _frontEnd = frontEnd;
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

        public void HandleUserInput(int control)
        {
            bool songPlaying = true;

            switch (control)
            {
                case 0:
                    Environment.Exit(0);
                    break;

                case 1:
                    songPlaying = PausePlay(songPlaying);
                    break;

                case 2:
                    StopPlaying();
                    break;

                case 3:
                    GetVolume();
                    Volume(songPlaying, GetVolume());
                    break;

                case 4:
                    MuteUnmute(songPlaying);
                    break;

                default:
                    Console.WriteLine("Incorrect input.");
                    Console.Clear();
                    _frontEnd.PrintMenu();
                    break;
            }
            Console.Clear();
            Something();
        }

        public void Something() //ToDo: verander naam
        {
            _frontEnd.PrintMenu();
            int control = _frontEnd.GetUserInput();
            HandleUserInput(control);
        }
    }
}