using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private IFileDownloader _fileDownloader;

        public InstallerHelper(string setupDestinationFile, IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
            _setupDestinationFile = setupDestinationFile;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _fileDownloader.DownloadFile(
                string.Format("http://example.com/{0}/{1}",
                    customerName,
                    installerName),
                _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }

    public interface IFileDownloader
    {
        void DownloadFile(string url, string path);
    }

    public class FileDownloader : IFileDownloader
    {
        private readonly WebClient _client;

        public FileDownloader()
        {
            _client = new WebClient();
        }

        public void DownloadFile(string url, string path)
        {
            _client.DownloadFile(url, path);
        }
    }

}