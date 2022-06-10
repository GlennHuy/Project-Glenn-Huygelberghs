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
            if (volume >=0 && volume <= 100)
            {
                if (volume == 0)
                {
                    Console.WriteLine("You ARE aware the mute function exists, yes?");
                    _player.settings.volume = volume;
                }
                else
                {
                    _player.settings.volume = volume;
                }
            }
            else
            {  //ToDo: finish
                Console.WriteLine("How did you mess that up?");
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
        }

        public void StopPlaying()
        {
            _player.controls.stop();
        }

        public void HandleUserInput(UserChoice control)
        {
            bool songPlaying = true;

            switch (control)
            {
                case UserChoice.Exit:
                    Environment.Exit(0);
                    break;

                case UserChoice.PausePlay:
                    songPlaying = PausePlay(songPlaying);
                    break;

                case UserChoice.StopPlaying:
                    StopPlaying();
                    break;

                case UserChoice.Volume:
                    _frontEnd.ShowVolumeRange();
                    Volume(_frontEnd.GetVolume());
                    break;

                case UserChoice.MuteUnmute:
                    MuteUnmute(songPlaying);
                    break;

                case UserChoice.NewSong:
                    //ToDo: Make it possible to choose a new song
                    break;

                default:
                    Console.WriteLine("I'm sorry, was choosing one of 6 options too hard? Try again.");
                    Console.Clear();
                    _frontEnd.PrintMenu();
                    break;
            }
            Console.Clear();
            Execute();
        }

        public void Execute() //ToDo: verander naam
        {
            _frontEnd.PrintMenu();
            int control = _frontEnd.GetUserInput();
            HandleUserInput((UserChoice)control);
        }
    }
}