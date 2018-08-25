using System;
using System.Collections.Generic;
using System.Text;

namespace CrashCourse
{
    public class UserInterface
    {
        public static void InitiateMainMenu()
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
            int validInput;

            if (int.TryParse(input, out validInput))
            {
                switch (validInput)
                {
                    case 1:
                        InitiateCreateVideoMenu();
                        break;
                    case 2:
                        InitiateVideoListMenu();
                        break;
                    case 3:
                        InitiateVideoEditingMenu();
                        break;
                    case 4:
                        InitiateVideoDeletingMenu();
                        break;
                    case 5:
                        Functions.Exit();
                        break;
                    default:
                        Console.WriteLine("\nThe given input must be a from the table above.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nYour given input must be a numerical from the table above.");
            }
            Console.ReadLine();
            InitiateMainMenu();
        }

        public static void InitiateCreateVideoMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "| Creating a new video |\n" +
                "|______________________|\n" +
                "- Enter name of video:");
            string videoName = Console.ReadLine();

            Console.WriteLine(
                "- Enter video genre:");
            string videoGenre = Console.ReadLine();

            Functions.CreateVideo(videoName, videoGenre);
        }

        public static void InitiateVideoListMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "| Showing all videos |\n" +
                "|____________________|\n");
            Functions.GetVideos();
        }

        public static void InitiateVideoEditingMenu()
        {
            Console.WriteLine(
                "|  Editing a video  |\n" +
                "|___________________|\n" +
                "- Enter video id:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int tempId))
            {
                Functions.EditVideo(tempId);
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }

        public static void InitiateVideoDeletingMenu()
        {
            Console.WriteLine(
                "| Deleting a video |\n" +
                "|__________________|\n" +
                "- Enter video id");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int tempId))
            {
                Functions.DeleteVideo(tempId);
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
