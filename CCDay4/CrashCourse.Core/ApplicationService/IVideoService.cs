using CrashCourse.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrashCourse.Core.ApplicationService
{
    public interface IVideoService
    {
        /* 
         * Video NewVideo(string videoName, string videoGenre);
         */
        Video NewVideo(string name, string genre);

        Video CreateVideo(Video video);

        Video GetVideo(int id);
        List<Video> GetAllVideos();

        Video UpdateVideo(Video video);

        Video DeleteVideo(int id);
    }
}
