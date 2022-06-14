namespace ConsoleMusicPlayer
{
    public class FrontEnd
    {
        public void PrintTitle() //ToDo: Make Fancy
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

        public void PrintMenu() // ToDo: Make Fancy
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|\t 1 \t|\t 2 \t |\t 3 \t|\t 4 \t|\t 5 \t|\t 0 \t|");
            Console.WriteLine("| Pause/Play | Stop | Volume | Mute/Unmute | New Song | Quit |");
            Console.ResetColor();
        }

        public int GetUserInput()
        {
            int control = Convert.ToInt32(Console.ReadLine());
            return control;
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

        public int GetVolume()
        {
            int volume = Convert.ToInt32(Console.ReadLine());
            return volume;
        }

        public void NewSongChoice()
        {
            Console.WriteLine("Enter the path of the new song you want to play.");
        }
    }
}