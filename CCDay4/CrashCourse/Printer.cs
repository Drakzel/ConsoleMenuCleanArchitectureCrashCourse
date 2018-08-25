using CrashCourse.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrashCourse
{
    public class Printer : IPrinter
    {
        PrinterFunctions printerFunctions = new PrinterFunctions();
        readonly IVideoService _videoService;

        public Printer(IVideoService videoService)
        {
            _videoService = videoService;
        }

        //Considering the build of a PrinterFunctions class
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
                        InitiateUpdateVideoMenu();
                        break;
                    case 4:
                        InitiateDeleteVideoMenu();
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

            Console.Clear();
            Console.WriteLine(
                "| Created video |\n" +
                "|_______________|\n");
            printerFunctions.PrintVideo(video);
        }

        private void InitiateVideoListMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "| Showing all videos |\n" +
                "|____________________|\n");
            var videos = _videoService.GetAllVideos();

            printerFunctions.PrintVideo(videos);
        }

        private void InitiateUpdateVideoMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "| Updating a selected video |\n" +
                "|___________________________|\n" +
                "- Enter id of video:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int videoId))
            {
                var video = _videoService.GetVideo(videoId);

                if (video == null)
                {
                    Console.WriteLine("Invalid id, video not found.");
                }
                else
                {
                    Console.WriteLine(
                        "\n| Selected video |\n" +
                          "|________________|");
                    printerFunctions.PrintVideo(video);

                    Console.WriteLine("- Enter a new name:");
                    string newName = Console.ReadLine();

                    Console.WriteLine();

                    Console.WriteLine("- Enter a new genre:");
                    string newGenre = Console.ReadLine();
                    
                    video.VideoGenre = newGenre;
                    video.VideoName = newName;
                    video = _videoService.UpdateVideo(video);

                    Console.Clear();
                    Console.WriteLine(
                        "| Updated Video |\n" +
                        "|_______________|\n");
                    printerFunctions.PrintVideo(video);
                }
            }
            else
            {
                Console.WriteLine("Your entered id, must be a number.");
            }
        }

        private void InitiateDeleteVideoMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "| Deleting a selected video |\n" +
                "|___________________________|\n" +
                "- Enter id of video:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int verifiedNumber))
            {
                var video = _videoService.DeleteVideo(verifiedNumber);
                if (video != null)
                {
                    Console.Clear();
                    Console.WriteLine(
                        "| Selected video has been deleted |\n" +
                        "|_________________________________|\n");
                    printerFunctions.PrintVideo(video);
                }
                else { Console.WriteLine("Invalid id, video not found"); }
            }
        }
    }
}
