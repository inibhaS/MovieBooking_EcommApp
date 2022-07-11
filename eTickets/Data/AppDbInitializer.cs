using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                //Add all Data
                //Cinema

                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(
                        new List<Cinema>()
                    {
                      new Cinema()
                    {
                        Name="Cinema1",
                        Logo= "https://dotnethow.net/images/cinemas/cinema-2.jpeg",
                        Description= "This is the description of first cinema"

                    },
                    new Cinema()
                    {

                         Name="Cinema2",
                        Logo= "https://dotnethow.net/images/cinemas/cinema-3.jpeg",
                        Description= "This is the description of second cinema"

                    },new Cinema()
                    {


                         Name="Cinema3",
                        Logo= "https://dotnethow.net/images/cinemas/cinema-4.jpeg",
                        Description= "This is the description of third cinema"
                    }


                    });

                    context.SaveChanges();

                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                     new Actor()
                    {
                      FullName="Actor1",
                      Bio="this is Bio of first Actor",
                      ProfilePictureUrl="http://dotnethow.net/images/actors/actor-2.jpeg",


                    },
                     new Actor()
                    {
                      FullName="Actor2",
                      Bio="this is Bio of second Actor",
                      ProfilePictureUrl="http://dotnethow.net/images/actors/actor-3.jpeg",


                    },
                     new Actor()
                    {
                      FullName="Actor3",
                      Bio="this is Bio of third Actor",
                      ProfilePictureUrl="http://dotnethow.net/images/actors/actor-4.jpeg",


                    },
                     new Actor()
                    {
                      FullName="Actor4",
                      Bio="this is Bio of fourth Actor",
                      ProfilePictureUrl="http://dotnethow.net/images/actors/actor-5.jpeg",


                    },

                    });
                    context.SaveChanges();


                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer1",
                            Bio = "this is Bio of first Producer",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"


                        },
                        new Producer()
                        {
                            FullName = "Producer2",
                            Bio = "this is Bio of 2 Producer",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"


                        },
                        new Producer()
                        {
                            FullName = "Producer3",
                            Bio = "this is Bio of 3 Producer",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                          },
                        new Producer()
                        {
                            FullName = "Producer4",
                            Bio = "this is Bio of 4 Producer",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"

                          }

                    });
                    context.SaveChanges();
                }
                //Movie
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                        {
                            new Movie()
                            {
                             Name="Andaaj",
                            Description="This is Cartoon Movie",
                            Price=39.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            CinemaId=1,
                            ProducerId=3,
                            MovieCategory=MovieCategory.Cartoon

                            },
                            new Movie()
                            {
                            Name="Cold Sales",
                            Description="This is Drama Movie",
                            Price=39.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            CinemaId=3,
                            ProducerId=5,
                            MovieCategory=MovieCategory.Drama

                             },

                            new Movie()
                            {
                            Name="Penthouse",
                            Description="This is Documentary Movie",
                            Price=39.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            CinemaId=2,
                            ProducerId=4,
                            MovieCategory=MovieCategory.Documentory

                             },
                            new Movie()
                            {
                            Name="Ghost",
                            Description="This is horror Movie",
                            Price=39.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-5.jpeg",
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            CinemaId=4,
                            ProducerId=4,
                            MovieCategory=MovieCategory.Horror

                             }

                        });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movies>() {
                    new Actor_Movies()
                    { ActorId=1,
                      MovieId=6
                    },
                     new Actor_Movies()
                    { ActorId=2,
                      MovieId=7
                     },
                      new Actor_Movies()
                    { ActorId=3,
                      MovieId=8
                    }
                });
                    context.SaveChanges();

                }
            }

         }

    }
}

