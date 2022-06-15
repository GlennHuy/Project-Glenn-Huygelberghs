using ConsoleMusicPlayer;
using WMPLib;


FrontEnd frontEnd = new FrontEnd();
WindowsMediaPlayer player = new WindowsMediaPlayer();
BackEnd backEnd = new BackEnd(player, frontEnd);

frontEnd.PrintTitle();

string song = frontEnd.GetSongChoice();

backEnd.Initialize(song);
bool songPlaying = true;

backEnd.ExecutePlayer(songPlaying);