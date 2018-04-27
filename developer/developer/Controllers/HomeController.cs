using developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace developer.Controllers
{
    public class HomeController : Controller
    {

        internal static ITwitterCredentials _credentials;
        public HomeController()
        {
            if (_credentials == null)
            {
                _credentials = GenerateCredentials();
            }
        }
        public static ITwitterCredentials GenerateCredentials()
        {
            return new TwitterCredentials(
                System.Configuration.ConfigurationManager.AppSettings["consumerKey"],
                System.Configuration.ConfigurationManager.AppSettings["consumerSecret"],
                System.Configuration.ConfigurationManager.AppSettings["accessToken"],
                System.Configuration.ConfigurationManager.AppSettings["accessTokenSecret"]);
        }



        public ActionResult Gonder()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Yaz(string benim_tweetim)
        {
            Auth.ExecuteOperationWithCredentials(_credentials, () =>
            {
                var publishOptions = new PublishTweetOptionalParameters();
                return Tweetinvi.Tweet.PublishTweet(benim_tweetim, publishOptions);
            }
           );

            return View();
        }


        public ActionResult About()
        {
            var Result = Auth.ExecuteOperationWithCredentials(_credentials, () =>
            {
                var tweets = Tweetinvi.Timeline.GetHomeTimeline(50);
                var profil = Tweetinvi.User.GetUserFromScreenName("saresare9416");
                var tt = Tweetinvi.Trends.GetTrendsAt(23424969);
                var gundem = tt.Trends;


                var friends = Tweetinvi.User.GetFriends("saresare9416", 250).ToList();
                var followers = Tweetinvi.User.GetFollowers("saresare9416", 250).ToList();


                HomePage model = new HomePage()
                {
                    Tweets = tweets.ToList(),
                    User = profil,
                    Trend = tt,
                    Gundem = gundem,
                    Friends = friends,

                    Followers = followers


                }; return model;
            }

            );
            ViewBag.Message = "Your application description page.";

            return View(Result);
        }

        public ActionResult Contact()
        {
            var Result = Auth.ExecuteOperationWithCredentials(_credentials, () =>
            {
                var tweets = Tweetinvi.Timeline.GetHomeTimeline(50).ToList();
                var profil = Tweetinvi.User.GetUserFromScreenName("saresare9416");
                var tt = Tweetinvi.Trends.GetTrendsAt(23424969);
                var gundem = tt.Trends.Take(20).ToList();

                var friends = Tweetinvi.User.GetFriends("saresare9416", 250).ToList();

                var followers = Tweetinvi.User.GetFollowers("saresare9416", 250).ToList();



                HomePage model = new HomePage()
                {

                    Tweets = tweets,
                    User = profil,
                    Trend = tt,
                    Gundem = gundem,

                    Friends = friends,

                    Followers = followers


                }; return model;
            }

            );
            return View(Result);
        }


        public ActionResult Anasayfa(string benim_tweetim)
        {
            var Result = Auth.ExecuteOperationWithCredentials(_credentials, () =>
             {
                 var tweets = Tweetinvi.Timeline.GetHomeTimeline(50).ToList();
                 var profil = Tweetinvi.User.GetUserFromScreenName("saresare9416");
                 
                 var tt = Tweetinvi.Trends.GetTrendsAt(23424969);
                 var gundem = tt.Trends.Take(20).ToList();

                 var friends = Tweetinvi.User.GetFriends("saresare9416", 250).ToList();

                 var followers = Tweetinvi.User.GetFollowers("saresare9416", 250).ToList();

                 var mytwt = Tweetinvi.User.GetUserFromScreenName("saresare9416").GetUserTimeline(50).ToList();

                 //var suggestedcaegories = Account.GetUserIdsRequestingFriendship(70).ToList();


                 //var suggestedcat = Account.GetSuggestedCategories().ToList();
                 //var suser = Tweetinvi.Account.GetSuggestedUsers("Result").ToList();

                 //var suggestedusers = new List<IUser>();
                 //var a = new Tweetinvi.Controllers.Account.AccountQueryExecutor(null,null);
                 //var ab = a.GetSuggestedUsers("Twitter", Language.Turkish);
                 ////a.get
                 //foreach (var usercategory in suser.Take(15))
                 //{
                 //    suggestedusers.AddRange(Account.GetSuggestedUsers(usercategory.ProfileImageUrlHttps));
                 //}



                 var arkadaslık_istek = Tweetinvi.Account.GetUserIdsRequestingFriendship(70);

                 //var kullanıcı_listesi = Tweetinvi.Account.GetSuggestedUsers().ToList();

                 //var kullanıcı_listesi = Tweetinvi.Account.GetMutedUserIds();



                 var requested_users = new List<IUser>();



                 //foreach (var item in arkadaslık_istek.Take(70))
                 //{
                 //    requested_users.AddRange(Account.GetUserIdsRequestingFriendship(70));


                 //}




                 HomePage model = new HomePage()
                 {

                     Tweets = tweets,
                     User = profil,
                     Trend = tt,
                     Gundem = gundem,

                     Friends = friends,

                     Mytwt = mytwt,
                     Followers = followers,
                     //Suser = suggestedusers


                 }; return model;
             }

           );

            return View(Result);
        }


        public ActionResult Profil()
        {

            var Result = Auth.ExecuteOperationWithCredentials(_credentials, () =>
            {
                var tweets = Tweetinvi.Timeline.GetHomeTimeline(50).ToList();
                var profil = Tweetinvi.User.GetUserFromScreenName("saresare9416");
                var tt = Tweetinvi.Trends.GetTrendsAt(23424969);
                var gundem = tt.Trends;

                var friends = Tweetinvi.User.GetFriends("saresare9416", 250).ToList();

                var followers = Tweetinvi.User.GetFollowers("saresare9416", 250).ToList();

                var mytwt = Tweetinvi.User.GetUserFromScreenName("saresare9416").GetUserTimeline(50).ToList();

                HomePage model = new HomePage()
                {
                    Tweets = tweets,

                    User = profil,
                    Trend = tt,
                    Gundem = gundem,

                    Friends = friends,

                    Followers = followers,

                    Mytwt = mytwt,

                }; return model;
            }

           );


            return View(Result);
        }

        public ActionResult Friends_profil()
        {
            var Result = Auth.ExecuteOperationWithCredentials(_credentials, () =>
            {
                var tweets = Tweetinvi.Timeline.GetHomeTimeline(50);
                var profil = Tweetinvi.User.GetUserFromScreenName("saresare9416");
                var tt = Tweetinvi.Trends.GetTrendsAt(23424969);
                var gundem = tt.Trends;

                var friends = Tweetinvi.User.GetFriends("saresare9416", 250).ToList();

                var followers = Tweetinvi.User.GetFollowers("saresare9416", 250).ToList();


                HomePage model = new HomePage()
                {
                    Tweets = tweets.ToList(),
                    User = profil,
                    Trend = tt,
                    Gundem = gundem,

                    Friends = friends,

                    Followers = followers


                }; return model;
            }
            );
            return View(Result);

        }

        public ActionResult Takipedilen()
        {
            var Result = Auth.ExecuteOperationWithCredentials(_credentials, () =>
            {
                var tweets = Tweetinvi.Timeline.GetHomeTimeline(50);
                var profil = Tweetinvi.User.GetUserFromScreenName("saresare9416");
                var tt = Tweetinvi.Trends.GetTrendsAt(23424969);
                var gundem = tt.Trends;

                var friends = Tweetinvi.User.GetFriends("saresare9416", 250).ToList();

                var followers = Tweetinvi.User.GetFollowers("saresare9416", 250).ToList();


                HomePage model = new HomePage()
                {
                    Tweets = tweets.ToList(),
                    User = profil,
                    Trend = tt,
                    Gundem = gundem,
                    Friends = friends,

                    Followers = followers




                }; return model;
            }
            );
            return View(Result);

        }

        
        public ActionResult Takipci()
        {
            var Result = Auth.ExecuteOperationWithCredentials(_credentials, () =>
            {
                var tweets = Tweetinvi.Timeline.GetHomeTimeline(50);
                var profil = Tweetinvi.User.GetUserFromScreenName("saresare9416");
                var tt = Tweetinvi.Trends.GetTrendsAt(23424969);
                var gundem = tt.Trends;

                var friends = Tweetinvi.User.GetFriends("saresare9416", 250).ToList();

                var followers = Tweetinvi.User.GetFollowers("saresare9416", 250).ToList();

                var suggestedcaegories = Account.GetUserIdsRequestingFriendship(70).ToList();


                //var suggestedcat = Account.GetSuggestedCategories().ToList();
                //var suser = Tweetinvi.Account.GetSuggestedUsers("Result").ToList();

                //var suggestedusers = new List<IUser>();

                //foreach (var usercategory in suser.Take(15))
                //{
                //    suggestedusers.AddRange(Account.GetSuggestedUsers(usercategory.ProfileImageUrlHttps));
                //}


                HomePage model = new HomePage()
                {
                    Tweets = tweets.ToList(),
                    User = profil,
                    Trend = tt,
                    Gundem = gundem,

                    Friends = friends,

                    Followers = followers,

                    //Suser=suggestedusers


                }; return model;
            }
            );
            return View(Result);

        }


        public ActionResult Fav(long id)
        {
            var result = Auth.ExecuteOperationWithCredentials(_credentials, () =>
            {
                var tweet = Tweet.GetTweet(id);
                if (tweet != null)
                {
                    if (tweet.Favorited)
                    {
                        //tweet.RetweetCount--;

                        //FavoriteCount--;

                        //tweet.FavoriteCount(--);



                        tweet.UnFavorite();
                        return false;
                    }
                    else
                    {
                        //tweet.FavoriteCount--;

                        //tweet.RetweetCount++;

                        tweet.Favorite();
                        return true;
                    }
                }
                return false;
            }); ;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Rt(long id)
        {
            var result = Auth.ExecuteOperationWithCredentials(_credentials, () =>
            {
                var tweet = Tweet.GetTweet(id);
                if (tweet != null)
                {
                if (tweet.Retweeted)
                    {
                        tweet.UnRetweet();
                        return false;
                    }
                    else
                    {
                        tweet.PublishRetweet();
                        return true;
                    }
                }
                return false;
            }); ;
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Gundem_cek(string query)
        {
            var Result = Auth.ExecuteOperationWithCredentials(_credentials, () =>
            {
                var tweets = Tweetinvi.Timeline.GetHomeTimeline(100);
                var profil = Tweetinvi.User.GetUserFromScreenName("saresare9416");
                var tt = Tweetinvi.Trends.GetTrendsAt(23424969);
                var gundem = tt.Trends;
                var friends = Tweetinvi.User.GetFriends("saresare9416", 250).ToList();
                var followers = Tweetinvi.User.GetFollowers("saresare9416", 250).ToList();
                query = string.IsNullOrEmpty(query) ? "Bimser " : query;
                var yol = new SearchTweetsParameters(query)
                {
                    SearchType = SearchResultType.Mixed,
                    SearchQuery = query,




                };
                var twt = Search.SearchTweets(yol).ToList();
                HomePage model = new HomePage()
                {
                    Tweets = tweets.ToList(),
                    User = profil,
                    Trend = tt,
                    Gundem = gundem,
                    Friends = friends,
                    Yol=twt,
                    Followers = followers


                }; return model;
            }

            );
            ViewBag.Message = "Your application description page.";

            return View(Result);
        }

        public ActionResult Delete(long id)
        {
            var result = Auth.ExecuteOperationWithCredentials(_credentials, () =>
            {
                var tweet = Tweet.GetTweet(id);
                if (tweet != null)
                {
                   
                    
                        tweet.Destroy();
                        return true;
                    
                }
                return false;
            }); ;
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Takip_istegi()
        {
            var Result = Auth.ExecuteOperationWithCredentials(_credentials, () =>
            {
                var tweets = Tweetinvi.Timeline.GetHomeTimeline(50);
                var profil = Tweetinvi.User.GetUserFromScreenName("saresare9416");
                var tt = Tweetinvi.Trends.GetTrendsAt(23424969);
                var gundem = tt.Trends;

                var friends = Tweetinvi.User.GetFriends("saresare9416", 250).ToList();

                var followers = Tweetinvi.User.GetFollowers("saresare9416", 250).ToList();


                HomePage model = new HomePage()
                {
                    Tweets = tweets.ToList(),
                    User = profil,
                    Trend = tt,
                    Gundem = gundem,

                    Friends = friends,

                    Followers = followers

                }; return model;
            }
            );
            return View(Result);

        }


        public ActionResult Gundem_yazdir(long g_id)
        { 
            var result = Auth.ExecuteOperationWithCredentials(_credentials, () =>
            {
                var tweet = Tweet.GetTweet(g_id);
                if (tweet != null)
                {


                    tweet.Text.ToList();

                    return true;

                }
                return false;
            }); ;
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Gundem()
        {
            var gundemId = Request.QueryString["gundemid"];
            ViewBag.GundemId = gundemId;
            return View();
        }

    }
}