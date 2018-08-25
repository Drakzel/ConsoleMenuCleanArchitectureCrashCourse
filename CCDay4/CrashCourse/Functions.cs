using System;
using System.Collections.Generic;
using System.Text;

namespace CrashCourse
{
    public class Functions
    {
        static int id = 1;
        static List<Video> allVideos = new List<Video>();

        public static void Exit()
        {
            Environment.Exit(0);
        }

        public static void CreateVideo(string videoName, string videoGenre)
        {
            allVideos.Add(new Video()
            {
                Id = id++,
                VideoGenre = videoGenre,
                VideoName = videoName
            });
            Console.WriteLine("\nVideo added successfully!");
        }

        public static void GetVideos()
        {
            foreach (var item in allVideos)
            {
                Console.WriteLine(
                    "Name: {0}\n" +
                    "Genre: {1}\n" +
                    "Id: {2}\n", item.VideoName, item.VideoGenre, item.Id);
            }
        }

        public static Video GetVideo(int id)
        {
            Video videoFound = null;
            foreach (var item in allVideos)
            {
                if (id == item.Id)
                {
                    Console.WriteLine(
                        "|  Selected video  |\n" +
                        "|__________________|\n" +
                        "Name: {0}\n" +
                        "Genre: {1}\n" +
                        "Id: {2}\n", item.VideoName, item.VideoGenre, item.Id);
                    videoFound = item;
                }
            }
            if (videoFound == null)
            {
                Console.WriteLine(
                        "| Selected Id was not found |\n" +
                        "|___________________________|");
                return videoFound;
            }
            else
            {
                return videoFound;
            }
        }

        public static void EditVideo(int id)
        {
            Console.Clear();
            Video videoToEdit = GetVideo(id);

            if (videoToEdit != null)
            {
                Console.WriteLine(
                "\n- Enter new name");
                string newName = Console.ReadLine();

                Console.WriteLine(
                    "\n- Enter new genre");
                string newGenre = Console.ReadLine();

                videoToEdit.VideoName = newName;
                videoToEdit.VideoGenre = newGenre;

                Console.WriteLine("\nVideo edited successfully!");
            }
        }

        public static void DeleteVideo(int id)
        {
            Console.Clear();
            Video videoToDelete = GetVideo(id);
            if (videoToDelete != null)
            {
                allVideos.Remove(videoToDelete);

                Console.WriteLine("\nVideo deleted successfully!");
            }
        }
    }
}
