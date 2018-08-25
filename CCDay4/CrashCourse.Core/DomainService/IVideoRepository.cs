using CrashCourse.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrashCourse.Core.DomainService
{
    public interface IVideoRepository
    {
        Video CreateVideo(Video video);

        Video GetVideo(int id);
        List<Video> GetAllVideos();

        Video UpdateVideo(Video video);

        Video DeleteVideo(int id);
    }
}
