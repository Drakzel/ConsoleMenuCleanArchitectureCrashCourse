using CrashCourse.Core.DomainService;
using CrashCourse.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrashCourse.Infrastructure.Data.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private int id = 1;
        private List<Video> _videos = new List<Video>();

        public Video CreateVideo(Video video)
        {
            video.Id = id++;
            _videos.Add(video);
            return video;
        }

        public List<Video> GetAllVideos()
        {
            return _videos;
        }

        public Video GetVideo(int id)
        {
            foreach (var video in _videos)
            {
                if (video.Id == id)
                {
                    return video;
                }
            }
            return null;
        }

        public Video UpdateVideo(Video video)
        {
            var videoFromDb = GetVideo(video.Id);

            if (videoFromDb != null)
            {
                videoFromDb.VideoName = video.VideoName;
                videoFromDb.VideoGenre = video.VideoGenre;
                return videoFromDb;
            }

            return null;
        }
        
        public Video DeleteVideo(int id)
        {
            var videoFromDb = GetVideo(id);
            if (videoFromDb != null)
            {
                _videos.Remove(videoFromDb);
                return videoFromDb;
            }
            return null;
        }
    }
}
