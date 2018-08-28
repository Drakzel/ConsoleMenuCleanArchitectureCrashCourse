using CrashCourse.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrashCourse
{
    public class PrinterFunctions
    {
        public void PrintVideo(Video video)
        {
            Console.WriteLine(
                "Id: {0}\n" +
                "Name: {1}\n" +
                "Genre: {2}\n", video.Id, video.VideoName, video.VideoGenre);
        }

        public void PrintVideo(List<Video> videos)
        {
            foreach (var video in videos)
            {
                PrintVideo(video);
            }
        }

        /*
         *public string AskQuestion(string question)
         *{
         *  console.WriteLine(question);
         *  return string answer = console.ReadLine();
         *}
         */ 
    }
}
