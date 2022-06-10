using ConsoleMusicPlayer.Enums;
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

        public void Volume(int volume)
        {
            if (volume >= 0 && volume <= 100)
            {
                _player.settings.volume = volume;
            }
            else
            {  //ToDo: finish
                Console.WriteLine("Volume has to be a value between 0 and 100.");
                _frontEnd.ShowVolumeRange();
                Volume(_frontEnd.GetVolume());
                // try
                // {
                // _player.settings.volume = volume
                // }
                //  catch (FormatException)
                // {
                // Console.WriteLine($"The volume entered is not valid");
                // }
            }
        } //ToDo: finish this

        public bool StopPlaying()
        {
            _player.controls.stop();
            bool songPlaying = false;
            return songPlaying;
        }

        public void HandleUserInput(UserChoice control, bool songPlaying)
        {
            switch (control)
            {
                case UserChoice.Exit:
                    Environment.Exit(0);
                    break;

                case UserChoice.PausePlay:
                    songPlaying = PausePlay(songPlaying);
                    break;

                case UserChoice.StopPlaying:
                    songPlaying = StopPlaying();
                    break;

                case UserChoice.Volume:
                    _frontEnd.ShowVolumeRange();
                    Volume(_frontEnd.GetVolume());
                    Console.Clear();
                    break;

                case UserChoice.MuteUnmute:
                    MuteUnmute(songPlaying);
                    break;

                case UserChoice.NewSong:
                    _frontEnd.NewSongChoice();
                    string song = _frontEnd.GetUserChoice();
                    Initialize(song);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Choose one of the available options.");
                    _frontEnd.PrintMenu();
                    break;
            }
            ExecutePlayer(songPlaying);
        }

        public void ExecutePlayer(bool songPlaying)
        {
            _frontEnd.PrintMenu();
            int control = _frontEnd.GetUserInput();
            HandleUserInput((UserChoice)control, songPlaying);
        }
    }
}