using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installer;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installer = new InstallerHelper("", _fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_NoError_ReturnsTrue()
        {
            var result = _installer.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {
            _fileDownloader.Setup(c => 
                c.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>(); //we need to pass the same parameters as in execution place of this method

            var result = _installer.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }


    }
}
