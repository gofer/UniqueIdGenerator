using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniqueIdGenerator.Models;

namespace UniqueIdGenerator.ViewModels;

public sealed partial class MainWindowViewModel : ObservableObject
{
    /// <summary>
    /// ウィンドウタイトル
    /// </summary>
    public string Title => @"Unique ID Generator";

    /// <summary>
    /// GUID形式のID
    /// </summary>
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IdByText))]
    private Guid idByGuid = Guid.Empty;

    /// <summary>
    /// 文字列形式のID
    /// </summary>
    public string IdByText => IdGenerationService.ToControllerId(this.IdByGuid);

    public MainWindowViewModel()
    {
        this.IdByGuid = IdGenerationService.GenerateId();
    }

    [RelayCommand]
    private void OnGenerate()
    {
        this.IdByGuid = IdGenerationService.GenerateId();
    }
}
