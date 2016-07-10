using Microsoft.AspNetCore.Mvc;
using RevRadio.Data.Models;
using System;
using System.Collections.Generic;

namespace RevRadio.Designs.Controllers
{
    public class ArtistProfileController : Controller
    {
        public IActionResult Index()
        {
            var profile = new ArtistProfile();
            profile.Slug = "no-futures";
            profile.Name = "No Futures";
            profile.City = "Collinsville";
            profile.State = "IL";
            profile.ImageFileUrl = "http://lorempixel.com/400/400/";

            profile.Genres = new List<Genre>
            {
                new Genre
                {
                    Name = "Punk",
                    Slug = "punk"
                },
                new Genre
                {
                    Name = "Rock",
                    Slug = "rock"
                },
                new Genre
                {
                    Name = "Pop Punk",
                    Slug = "pop-punk"
                }
            };

            profile.Tracks = new List<Track>
            {
                new Track
                {
                    Title = "Title1",
                    ReleaseDate = DateTime.Now,
                    ReleaseTitle = "ReleaseTitle1",
                    AudioFileUrl = "https://archive.org/download/PeterHernandezPodcastAudioPlaceholder/AudioPlaceholder.mp3",
                    ImageFileUrl = "http://lorempixel.com/400/400/",
                    Artist = profile
                },
                new Track
                {
                    Title = "Title2",
                    ReleaseDate = DateTime.Now.AddDays(-1),
                    ReleaseTitle = "ReleaseTitle2",
                    AudioFileUrl = "https://archive.org/download/PeterHernandezPodcastAudioPlaceholder/AudioPlaceholder.mp3",
                    ImageFileUrl = "http://lorempixel.com/400/400/",
                    Artist = profile
                },
                new Track
                {
                    Title = "Title1",
                    ReleaseDate = DateTime.Now.AddDays(-2),
                    ReleaseTitle = "ReleaseTitle2",
                    AudioFileUrl = "https://archive.org/download/PeterHernandezPodcastAudioPlaceholder/AudioPlaceholder.mp3",
                    ImageFileUrl = "http://lorempixel.com/400/400/",
                    Artist = profile
                }
            };

            return View(profile);
        }
    }
}
