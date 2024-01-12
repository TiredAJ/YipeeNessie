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
    //private static LibVLC LVLC;

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
        YippeeAudio = new Uri("avares://YippeeNessie/Assets/Yippee.mp3", UriKind.Absolute);
        Nessie = new Bitmap(AssetLoader.Open(NessieLoc));

        //LVLC = new LibVLC("--file-caching=0");

        Debug.WriteLine($"Is uri file?: {YippeeAudio.IsFile}");

        //LVLC.Log += LVLC_Log;
    }

    private void LVLC_Log(object? sender, LogEventArgs e)
    { Debug.WriteLine(e.FormattedLog); }

    public void NessieTime()
    {

        //using (Media M = new Media(LVLC, new StreamMediaInput(AssetLoader.Open(YippeeAudio))))
        //{
        //    using (var MP = new MediaPlayer(M))
        //    {
        //        MP.Volume = 20;

        //        MP.Play();

        //        Debug.WriteLine(MP.Volume);

        //        //if (!MP.WillPlay)
        //        //{
        //        //    throw new Exception("Won't play audio");
        //        //}
        //        MP.Volume += 1;
        //    }
        //}
    }
}
