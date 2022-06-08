using WMPLib;

WindowsMediaPlayer player = new WindowsMediaPlayer();
string musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
player.URL = System.IO.Path.Combine(musicFolder, "Cathedrals of Mourning.mp3");
player.controls.play();