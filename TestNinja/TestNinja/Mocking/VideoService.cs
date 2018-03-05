using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IVideoRepository _repository;

        //public IFileReader FileReader { get; set; } // Dependency injection as property
        private IFileReader _fileReader { get; set; } // Dependency injection as constructor

        public VideoService(IFileReader fileReader = null, IVideoRepository repository = null)
        {
            //FileReader = new FileReader(); // Dependency injection as property
            _fileReader = fileReader ?? new FileReader(); // Dependency injection as constructor
            _repository = repository ?? new VideoRepository(); // Dependency injection as constructor
        }

        //public string ReadVideoTitle(IFileReader fileReader) //Dependency injection ans method parameter
        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            var videos = _repository.GetUnprocessedVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);

            //using (var context = new VideoContext())
            //{
            //    var videos = 
            //        (from video in context.Videos
            //        where !video.IsProcessed
            //        select video).ToList();
                
            //    foreach (var v in videos)
            //        videoIds.Add(v.Id);

            //    return String.Join(",", videoIds);
            //}
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }

    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }

    public class VideoRepository : IVideoRepository
    {
        //private VideoContext _context;

        public IEnumerable<Video> GetUnprocessedVideos()
        {
            using (var context = new VideoContext())
            {
                var videos =
                (from video in context.Videos
                 where !video.IsProcessed
                 select video).ToList();

                return videos;
            }
        }
    }


}