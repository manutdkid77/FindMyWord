using Prism.Commands;
using Prism.Mvvm;
using Shiny.SpeechRecognition;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindMyWord.ViewModels
{
    public class SearchPageViewModel : BindableBase
    {
        readonly ISpeechRecognizer _speechRecognizer;
        public SearchPageViewModel(ISpeechRecognizer speechRecognizer)
        {
            _speechRecognizer = speechRecognizer;
        }
    }
}
