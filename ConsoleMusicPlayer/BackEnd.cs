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
                    songPlaying = true;
                    _player.controls.pause();
                    return songPlaying;

                case false:
                    songPlaying = false;
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

        public void Volume(string volume)
        {
            int volValue;
            bool isNumber = int.TryParse(volume, out volValue);
            if (isNumber == true)
            {
                if (volValue >= 0 && volValue <= 100)
                {
                    _player.settings.volume = volValue;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Volume has to be a value between 0 and 100.");
                    Console.ResetColor();
                    _frontEnd.ShowVolumeRange();
                    Volume(_frontEnd.GetVolume());
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Volume has to be a number.");
                Console.ResetColor();
                _frontEnd.ShowVolumeRange();
                Volume(_frontEnd.GetVolume());
            }
        }

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
                    Console.WriteLine("Exiting Mediaplayer.");
                    Environment.Exit(0);
                    break;

                case UserChoice.PausePlay:
                    songPlaying = PausePlay(songPlaying);
                    Console.Clear();
                    break;

                case UserChoice.StopPlaying:
                    songPlaying = StopPlaying();
                    Console.Clear();
                    break;

                case UserChoice.Volume:
                    _frontEnd.ShowVolumeRange();
                    Volume(_frontEnd.GetVolume());
                    Console.Clear();
                    break;

                case UserChoice.MuteUnmute:
                    MuteUnmute(songPlaying);
                    Console.Clear();
                    break;

                case UserChoice.NewSong:
                    _frontEnd.NewSongChoice();
                    string song = _frontEnd.GetUserChoice();
                    Initialize(song);
                    Console.Clear();
                    break;

                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choose one of the available options.");
                    Console.ResetColor();
                    break;
            }
            _frontEnd.IsMuted(_player.settings.mute);
            ExecutePlayer(songPlaying);
        }

        public int CheckValidInput(string userInput)
        {
            int control;
            int.TryParse(userInput, out control);
            return control;
        }

        public void ExecutePlayer(bool songPlaying)
        {
            _frontEnd.PrintMenu();
            int control = _frontEnd.GetMenuInput();
            HandleUserInput((UserChoice)control, songPlaying);
        }
    }
}