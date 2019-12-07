using EqualRights.Service.Interface;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EqualRights.ViewModels
{
    public class AboutAppViewModel : ViewModelBase
    {
        private string _pdfPath;

        private DelegateCommand _openGoogleDocsPdfCommand;
        public DelegateCommand OpenGoogleDocsPdfCommand =>
            _openGoogleDocsPdfCommand ?? (_openGoogleDocsPdfCommand = new DelegateCommand(ExecuteOpenGoogleDocsPdfCommand));

        void ExecuteOpenGoogleDocsPdfCommand()
        {
            NavigationService.NavigateAsync("ViewPdfOnlineView");
        }

        private IDocumentViewer _documentViewer;

        private DelegateCommand _openPdfCommand;
        public DelegateCommand OpenPdfCommand =>
            _openPdfCommand ?? (_openPdfCommand = new DelegateCommand(ExecuteOpenPdfCommand));

        public AboutAppViewModel(INavigationService navigationService, IDocumentViewer documentViewer, IMenuService menuService ) : base(navigationService)
        {
            _pdfPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            _documentViewer = documentViewer;
        }

        void ExecuteOpenPdfCommand()
        {
            CopyEmbeddedContent("EqualRights.pdfFile.Rights.pdf", "Rights.pdf");

            _documentViewer.ViewDocument(_pdfPath, "Rights.pdf");
        }

        private void CopyEmbeddedContent(string resourceName, string outputFileName)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            using (Stream resFilestream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resFilestream == null) return;
                byte[] ba = new byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);

                File.WriteAllBytes(Path.Combine(_pdfPath, outputFileName), ba);
            }
        }





    }
}
