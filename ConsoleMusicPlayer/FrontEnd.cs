﻿namespace ConsoleMusicPlayer
{
    public class FrontEnd
    {
        public void PrintTitle()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
___  ___ ___________ _____  ___  ______ _       _____   _____________
|  \/  ||  ___|  _  \_   _|/ _ \ | ___ \ |     / _ \ \ / /  ___| ___ \
| .  . || |__ | | | | | | / /_\ \| |_/ / |    / /_\ \ V /| |__ | |_/ /
| |\/| ||  __|| | | | | | |  _  ||  __/| |    |  _  |\ / |  __||    /
| |  | || |___| |/ / _| |_| | | || |   | |____| | | || | | |___| |\ \
\_|  |_/\____/|___/  \___/\_| |_/\_|   \_____/\_| |_/\_/ \____/\_| \_|
");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Enter the path to a song.");
            Console.ResetColor();
        }

        public void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|1 : Pause/Play\t|");
            Console.WriteLine("|2 : Stop\t|");
            Console.WriteLine("|3 : Volume\t|");
            Console.WriteLine("|4 : Mute/Unmute|");
            Console.WriteLine("|5 : New Song\t|");
            Console.WriteLine("|0 : Quit\t|");
            Console.ResetColor();
        }

        public int GetMenuInput()
        {
            int control;
            string userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Choose one of the available options.");
                Console.ResetColor();
                return GetMenuInput();
            }
            else if (!int.TryParse(userInput, out control))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Choose one of the available options designated by their numbers.");
                Console.ResetColor();
                return GetMenuInput();
            }
            else
            {
                control = Convert.ToInt32(userInput);
                return control;
            }
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

        public void ShowVolumeRange()
        {
            Console.WriteLine("Pick volume percentage.");
        }

        public string GetVolume()
        {
            string volume = Console.ReadLine();
            return volume;
        }

        public void IsMuted(bool muteStatus)
        {
            if (muteStatus == true)
            {
                Console.WriteLine("Song is currently muted.");
            }
        }

        public void NewSongChoice()
        {
            Console.WriteLine("Enter the path of the new song you want to play.");
        }
    }
}