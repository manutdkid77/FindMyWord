using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using Shiny.SpeechRecognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyWord.ViewModels
{
    public class SearchPageViewModel : BindableBase
    {
        readonly ISpeechRecognizer _speechRecognizer;
        readonly IPageDialogService _pageDialogService;

        public DelegateCommand RequestPermissionCommand { get; set; }
        public DelegateCommand ListenCommand { get; set; }

        private string _ListenedText;
        public string ListenedText
        {
            get { return _ListenedText; }
            set { SetProperty(ref _ListenedText, value); }
        }
        public SearchPageViewModel(ISpeechRecognizer speechRecognizer, IPageDialogService pageDialogService)
        {
            _speechRecognizer = speechRecognizer;
            _pageDialogService = pageDialogService;
            ListenCommand = new DelegateCommand(ListenCommandExecuted);
        }

        private async Task<bool> SpeechAccessGranted()
        {
            var granted = await _speechRecognizer.RequestAccess();
            if (granted == Shiny.AccessState.Available)
                return true;
            else
                return false;
        }

        private async void ListenCommandExecuted()
        {
            try
            {
                var granted = await SpeechAccessGranted();
                if (!granted)
                    return;

                _speechRecognizer.ListenForFirstKeyword().Subscribe(x => ListenedText = x);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
