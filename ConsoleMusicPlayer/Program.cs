﻿using ConsoleMusicPlayer;
using WMPLib;

FrontEnd frontEnd = new FrontEnd();
BackEnd backEnd = new BackEnd();

frontEnd.PrintTitle();
string song = backEnd.GetUserChoice();

WindowsMediaPlayer player = new WindowsMediaPlayer();
backEnd.Initialize(song);

int control;
bool songPlaying = true;
do
{
    frontEnd.PrintMenu();
    control = Convert.ToInt32(Console.ReadLine());
    switch (control)
    {
        case 2:
            player.controls.stop();
            break;
        case 1:
            backEnd.PausePlay(songPlaying);
            break;
        case 4:
            backEnd.MuteUnmute(songPlaying);
            break;
        case 0:
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Incorrect input.");
            Console.Clear();
            frontEnd.PrintMenu();
            break;
    }
    Console.Clear();
} while (control == 1 || control == 2 || control == 3 || control == 4 || control == 5 || control == 0);

