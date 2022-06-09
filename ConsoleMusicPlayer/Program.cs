using ConsoleMusicPlayer;
using WMPLib;

FrontEnd frontEnd = new FrontEnd(); 
BackEnd backEnd = new BackEnd();

frontEnd.PrintTitle();
string song = backEnd.GetUserChoice();
frontEnd.PrintMenu();

WindowsMediaPlayer player = new WindowsMediaPlayer();
string musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
player.URL = Path.Combine(musicFolder, song);
player.controls.play();
bool songStatus = true;
string control = Console.ReadLine();
do
{
    switch (control = Console.ReadLine())
    {
        case "s":
            player.controls.stop();
            break;
        case "p":
            if (songStatus == true)
            {
                songStatus = false;
                player.controls.pause();
            }
            else if (songStatus == false)
            {
                songStatus = true;
                player.controls.play();
            }
            break;
        default:
            Console.WriteLine($"Enter a valid command. s to stop p to pause and play.");
            break;
    }
} while (control == "s" || control == "p");
