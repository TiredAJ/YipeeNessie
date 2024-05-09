// Ignore Spelling: Nessie

using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ManagedBass;
using ReactiveUI;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace YippeeNessie.ViewModels;

public class MainViewModel : ViewModelBase
{
    private static int SHandle = 0;
    private Uri Audio =>
        new Uri("avares://YippeeNessie/Assets/Yippee.mp3");
    private Uri NessieLoc =>
        new Uri("avares://YippeeNessie/Assets/Green_Nessie.png");

    private Bitmap _Nessie;
    public Bitmap Nessie
    {
        get => _Nessie;

        private set
        { this.RaiseAndSetIfChanged(ref _Nessie, value); }
    }

    private bool _ShowNessie = false;
    public bool ShowNessie
    {
        get => _ShowNessie;
        set
        { this.RaiseAndSetIfChanged(ref _ShowNessie, value); }
    }

    public MainViewModel()
    {
        Nessie = new Bitmap(AssetLoader.Open(NessieLoc));
        Bass.Init(-1);

        using (FileStream FS = File.OpenWrite(Path.GetTempFileName()))
        {
            AssetLoader.Open(Audio).CopyTo(FS);
            SHandle = Bass.CreateStream(FS.Name);
        }
    }

    public void NessieTime()
    {
        Debug.WriteLine(Bass.LastError);

        Bass.ChannelPlay(SHandle, true);

        ShowNessie = true;

        Task.Run(() =>
        {
            Thread.Sleep(2000);

            ShowNessie = false;
        });
    }
}
