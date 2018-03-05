using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IVideoRepository> _repository;
        private Mock<IFileReader> _fileReader;

        // Test with manual mocking object, withour mocking framework
        //[Test]
        //public void ReadVideoToTitle_EmptyFile_ReturnsError()
        //{
        //    var service = new VideoService();
        //    service.FileReader = new FakeFileReader(); // Dependency injection as property

        //    //var result = service.ReadVideoTitle(new FakeFileReader()); // Dependency injection as mehtod parameter
        //    var result = service.ReadVideoTitle(); // Dependency injection as property

        //    Assert.That(result, Does.Contain("error").IgnoreCase);
        //}

        //Good idea to use mocks in SetUp method
        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();            
            _repository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _repository.Object);
        }

        [Test]
        public void ReadVideoToTitle_EmptyFile_ReturnsError()
        {            
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            
            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnsAnEmptyString()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());
            
            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_ReturnAStringWithIdOfUnprocessedVideos()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video() { Id = 1},
                new Video() { Id = 2},
                new Video() { Id = 3}
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
