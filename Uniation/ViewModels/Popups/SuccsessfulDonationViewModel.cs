using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Stores;
using Newtonsoft.Json;
using System.IO;
using Uniation.Helpers;
using Uniation.Models;

namespace Uniation.ViewModels.Popups
{
    public partial class SuccsessfulDonationViewModel : ObservableObject
    {
        private ModalNavigationStore _modalNavigationStore;
        private readonly DonatedProject _project;
        public SuccsessfulDonationViewModel(DonatedProject project,ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
            _project = project;
            CreateLog();
        }

        [RelayCommand]
        private void Close()
        {
            _modalNavigationStore.CurrentViewModel = null;
        }

        private async void CreateLog()
        {
            if (_project != null)
            {

                string path = @"E:\MVS projects\Uniation\Uniation\donations.json";
                if (File.Exists(path))
                {
                    string jsonData = await File.ReadAllTextAsync(path);
                    List<DonatedProject> donates = JsonConvert.DeserializeObject<List<DonatedProject>>(jsonData) ?? new();
                    var repDonate = donates.FirstOrDefault(d => d.id == _project.id);
                    if (repDonate != null)
                    {
                        repDonate.sum += _project.sum;
                    }
                    else
                    {
                        donates.Add(_project);
                    }
                    string updJson = JsonConvert.SerializeObject(donates, Formatting.Indented);
                    await File.WriteAllTextAsync(path, updJson);
                }
                else
                {

                    string jsonstr = JsonConvert.SerializeObject(new List<DonatedProject>() { _project }, Formatting.Indented);
                    File.Create(path).Close();
                    await File.WriteAllTextAsync(path, jsonstr);
                }
            }
        }
    }
}
