using ConsoleMusicPlayer;
using WMPLib;


FrontEnd frontEnd = new FrontEnd();
WindowsMediaPlayer player = new WindowsMediaPlayer();
BackEnd backEnd = new BackEnd(player, frontEnd);

frontEnd.PrintTitle();

string song = frontEnd.GetSongChoice();
bool songPlaying = true;

backEnd.Initialize(song);

backEnd.ExecutePlayer(songPlaying);