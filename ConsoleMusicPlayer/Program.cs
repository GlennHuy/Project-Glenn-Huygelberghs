using ConsoleMusicPlayer;
using WMPLib;

FrontEnd frontEnd = new FrontEnd();
WindowsMediaPlayer player = new WindowsMediaPlayer();
BackEnd backEnd = new BackEnd(player, frontEnd);

frontEnd.PrintTitle();
string song = frontEnd.GetUserChoice();
bool songPlaying = true;

backEnd.Initialize(song);
player.settings.volume = 0; // ToDo : delete this

backEnd.ExecutePlayer(songPlaying);

