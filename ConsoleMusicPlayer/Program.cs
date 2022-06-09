using ConsoleMusicPlayer;
using WMPLib;

FrontEnd frontEnd = new FrontEnd(); 
BackEnd backEnd = new BackEnd();

frontEnd.PrintTitle();
string song = backEnd.GetUserChoice();


WindowsMediaPlayer player = new WindowsMediaPlayer();
string musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
player.URL = Path.Combine(musicFolder, song);
player.controls.play();

frontEnd.PrintMenu();
bool songPlaying = true;
string control = Console.ReadLine();
while (control == "s" || control == "p")
{
    
    switch (control)
    {
        case "s":
            player.controls.stop();
            songPlaying = false;
            break;
        case "p":
            if (songPlaying == true)
            {
                songPlaying = false;
                player.controls.pause();
            }
            else if (songPlaying == false)
            {
                songPlaying = true;
                player.controls.play();
            }
            break;
        default:
            Console.WriteLine("Incorrect input.");
            Console.Clear();
            frontEnd.PrintMenu();
            break;
    }
    control = Console.ReadLine();
}

