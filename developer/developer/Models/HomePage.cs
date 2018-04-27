using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace developer.Models
{
    public class HomePage
    {

        public List<Tweetinvi.Models.ITweet> Tweets { get; set; }
        public Tweetinvi.Models.IUser User { get; set; }
        public Tweetinvi.Models.IPlaceTrends Trend { get; set; }
        public List<Tweetinvi.Models.ITrend> Gundem { get; set; }
        public List<Tweetinvi.Models.ITweet> Yol { get; set; }
        public List<Tweetinvi.Models.IUser> Friends { get; set; }
        public List<Tweetinvi.Models.IUser> Followers { get; set; }
        public List<Tweetinvi.Models.ITweet> Mytwt{ get; set; }

        public List<Tweetinvi.Models.IUser> user { get; set; }



        //public List<Tweetinvi.Models.IUser> Kimi_takip_etmeli { get; set; }


    }
}