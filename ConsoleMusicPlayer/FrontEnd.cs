namespace ConsoleMusicPlayer
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
            Console.WriteLine(@"
╔═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╗
║        1      ║       2       ║        3      ║       4       ║       5       ║       0       ║
╟───────────────╫───────────────╫───────────────╫───────────────╫───────────────╫───────────────╢
║   Pause/Play  ║     Stop      ║ Change Volume ║  Toggle Mute  ║   New Song    ║     Quit      ║
╚═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╝");
            Console.ResetColor();
        }
        public string GetMenuInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }

        public string GetSongChoice()
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
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Song is currently muted.");
                Console.ResetColor();
            }
        }

        public void NewSongChoice()
        {
            Console.WriteLine("Enter the path of the new song you want to play.");
        }
        public void ErrorMenuType()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Program only responds to the numbers displayed.");
            Console.ResetColor();
        }
        public void ErrorVolumeNumber()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Volume has to be a number.");
            Console.ResetColor();
        }
        public void ErrorVolumeRange()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error :Volume has to be a value between 0 and 100.");
            Console.ResetColor();
        }
        public void ErrorDefault()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Choose one of the available options.");
            Console.ResetColor();
        }
    }
}