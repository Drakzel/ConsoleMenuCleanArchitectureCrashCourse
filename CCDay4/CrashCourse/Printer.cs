using CrashCourse.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrashCourse
{
    public class Printer : IPrinter
    {
        readonly IVideoService _videoService;

        public Printer(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public void InitiateMainMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "| Enter given numerical parameter |\n" +
                "|_________________________________|\n" +
                "Press 1 to: Create video.\n" +
                "Press 2 to: Get listed videos.\n" +
                "Press 3 to: Edit a video.\n" +
                "Press 4 to: Delete a video.\n" +
                "Press 5 to: Exit.");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int verifiedNumber))
            {
                switch (verifiedNumber)
                {
                    case 1:
                        InitiateCreateVideoMenu();
                        break;
                    case 2:
                        InitiateVideoListMenu();
                        break;
                    case 3:
                        //InitiateUpdateVideoMenu();
                        break;
                    case 4:
                        //InitiateDeleteVideoMenu();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Given input must be within parameter options.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Your given input must be a number.");
            }
            Console.ReadLine();
            InitiateMainMenu();
        }

        private void InitiateCreateVideoMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "| Creating a new video |\n" +
                "|______________________|\n" +
                "- Enter name of video:");
            string nameOfNewVideo = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine(
                "- Enter video genre:");
            string genreOfNewVideo = Console.ReadLine();

            var video = _videoService.NewVideo(nameOfNewVideo, genreOfNewVideo);
            video = _videoService.CreateVideo(video);

            Console.WriteLine("\n\nThe following video has been added to the library.\n" +
                "Name: {0}\n" +
                "Genre: {1}\n" +
                "Id: {2}", video.VideoName, video.VideoGenre, video.Id);
        }

        private void InitiateVideoListMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "| Showing all videos |\n" +
                "|____________________|\n");
            var videos = _videoService.GetAllVideos();

            foreach (var video in videos)
            {
                Console.WriteLine(
                    "Name: {0}\n" +
                    "Genre: {1}\n" +
                    "Id: {2}\n", video.VideoName, video.VideoGenre, video.Id);
            }
        }
    }
}
