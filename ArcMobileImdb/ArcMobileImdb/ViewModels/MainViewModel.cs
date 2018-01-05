using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;
using GalaSoft.MvvmLight;

namespace ArcMobileImdb.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly Lazy<IApiMovieRequest> _moviesRequest;
        private ObservableCollection<Movie> _movieList;
        private int _lastLoadedPage;

        public ObservableCollection<Movie> MovieList
        {
            get { return _movieList; }
            set { _movieList = value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {

            MovieDbFactory.RegisterSettings(Constants.API_KEY);
            _moviesRequest = MovieDbFactory.Create<IApiMovieRequest>();

        }


        public async void Load()

        {
            var apiMovieList = await _moviesRequest.Value.GetNowPlayingAsync(_lastLoadedPage + 1);
            if (MovieList == null) MovieList = new ObservableCollection<Movie>();
            if (apiMovieList.Results == null) return;
            foreach (var result in apiMovieList.Results)
            {
                MovieList.Add(result);
            }
            ++_lastLoadedPage;
        }

    }
}
