using System;
using System.Linq;
using System.Threading.Tasks;
using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArcMobileImdb.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {

            MovieDbFactory.RegisterSettings(Constants.API_KEY);
            var r = MovieDbFactory.Create<IApiMovieRequest>();
            var result = r.Value.GetNowPlayingAsync();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result.Results.Any());
        }

    }
}
