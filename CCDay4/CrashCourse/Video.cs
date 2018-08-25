using System;
using System.Collections.Generic;
using System.Text;

namespace CrashCourse
{
    public class Video
    {
        public string VideoName { get; set; }
        //Why write get/set? without it, it is simply an open field for anyone to change
        //Though it is mostly to be able to initiate code inside the get/set values.
        public int Id { get; set; }
        public string VideoGenre { get; set; }
    }
}
