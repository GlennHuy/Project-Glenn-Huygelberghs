using ConsoleMusicPlayer;
using WMPLib;

// Giving program access to frontend, backend, and mediaplayer.
FrontEnd frontEnd = new FrontEnd();
WindowsMediaPlayer player = new WindowsMediaPlayer();
BackEnd backEnd = new BackEnd(player, frontEnd);

frontEnd.PrintTitle();

string song = frontEnd.GetUserChoice();
bool songPlaying = true;

backEnd.Initialize(song);

backEnd.ExecutePlayer(songPlaying);