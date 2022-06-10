namespace ConsoleMusicPlayer
{
    public class FrontEnd
    {
        public void PrintTitle() //ToDo: Make Fancy
        {
            Console.WriteLine("MEDIAPLAYER");
            Console.WriteLine("Enter the path to a song. Or don't, I don't care.");
        }
        public void PrintMenu() // ToDo: Make Fancy
        {
            Console.WriteLine("Pick one.");
            Console.WriteLine("1 to pause or play \\ 2 to stop \\ 3 to change volume \\ 4 to mute/unmute \\ 5 to put on a new song \\ 0 to quit");
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
            Console.WriteLine("Pick volume percentage. Hint: Anywhere from 0 to 100.");
        }
        public int GetVolume()
        {
            int volume = Convert.ToInt32(Console.ReadLine());
            return volume;
        }
    }
}