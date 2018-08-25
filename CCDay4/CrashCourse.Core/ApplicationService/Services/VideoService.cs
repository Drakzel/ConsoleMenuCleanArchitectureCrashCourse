using CrashCourse.Core.ApplicationService;
using CrashCourse.Core.DomainService;
using CrashCourse.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrashCourse.Core.ApplicationService.Services
{
    public class VideoService : IVideoService
    {
        readonly IVideoRepository _videoRepo;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepo = videoRepository;
        }
        
        public Video NewVideo(string name, string genre)
        {
            var video = new Video()
            {
                VideoGenre = genre,
                VideoName = name
            };
            return video;
        }

        public Video CreateVideo(Video video)
        {
            return _videoRepo.CreateVideo(video);
        }

        public List<Video> GetAllVideos()
        {
            return _videoRepo.GetAllVideos();
        }

        public Video GetVideo(int id)
        {
            return _videoRepo.GetVideo(id);
        }

        public Video UpdateVideo(Video video)
        {
            return _videoRepo.UpdateVideo(video);
        }

        public Video DeleteVideo(int id)
        {
            return _videoRepo.DeleteVideo(id);
        }
    }
}
