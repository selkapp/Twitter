using Microsoft.Owin;
using Owin;
using System;
using Tweetinvi;

[assembly: OwinStartupAttribute(typeof(developer.Startup))]
namespace developer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
            Auth.SetUserCredentials("Q1bxqKYFvd5XIi7QiEltltUDg", "7llwMaIbIUpat8p2dmU1wLFiXtDr7ZLXOgNPcmI6ZQLidcEMMk", "884366513616166912-RGKwGk4o5X80cVIPYWL57CUSzzb5RNn", "wsuBR6s4gJtoBD9PxPC9Uw1rTevm7r0L9pplbl1RNVopL");
            var user = User.GetAuthenticatedUser();

            var tweet = Tweet.PublishTweet("Developer");
            var timelineTweets = Timeline.GetUserTimeline(user, 5);
            foreach (var timelineTweet in timelineTweets)
            {
                //Console.WriteLine(timelineTweet);
            }
           
        }
    }
}
