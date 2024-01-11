// Ignore Spelling: Nessie

using Avalonia.Media.Imaging;
using Avalonia.Platform;
using LibVLCSharp.Shared;
using ReactiveUI;
using System;
using System.Diagnostics;

namespace YippeeNessie.ViewModels;

public class MainViewModel : ViewModelBase
{
    private static LibVLC LVLC;

    private Media YippeeMedia;

    public Uri YippeeAudio { get; }
    private Uri NessieLoc =>
        new Uri("avares://YippeeNessie/Assets/Green_Nessie.png");

    private Bitmap _Nessie;
    public Bitmap Nessie
    {
        get => _Nessie;

        private set
        { this.RaiseAndSetIfChanged(ref _Nessie, value); }
    }

    private MediaPlayer MP { get; }

    private bool _ShowNessie = false;
    public bool ShowNessie
    {
        get => _ShowNessie;
        set
        { this.RaiseAndSetIfChanged(ref _ShowNessie, value); }
    }

    public MainViewModel()
    {
        YippeeAudio = new Uri("avares://YippeeNessie/Assets/Yippee.wav");
        Nessie = new Bitmap(AssetLoader.Open(NessieLoc));

        LVLC = new LibVLC();

        YippeeMedia = new Media(LVLC, YippeeAudio.AbsolutePath);

        LVLC.Log += LVLC_Log;
    }

    private void LVLC_Log(object? sender, LogEventArgs e)
    { Debug.WriteLine(e.FormattedLog); }

    public void NessieTime()
    {
        using (var MP = new MediaPlayer(YippeeMedia))
        {
            MP.Play();

            if (!MP.WillPlay)
            {
                throw new Exception("Won't play audio");
            }
            MP.Volume += 1;
        }
    }
}
