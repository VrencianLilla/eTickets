using eTickets.Models;

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

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",   //Cinema One Brasso
                            Logo = "",
                            Description = "Cinema One Brașov este destinația ideală pentru cinefilii care doresc să își petreacă timpul liber într-o atmosferă deosebită. Aici pot fi vizionate cele mai noi filme, într-un spațiu creat special pentru pasionații de film și spectacol."
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",   //Cinema City Maros
                            Logo = "",
                            Description = "Cinema City este cel mai mare operator de cinema din România şi face parte din Cineworld Group, al doilea mare lanţ de cinema din Europa."
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",   //Cineplexx Maros
                            Logo = "",
                            Description = "Cineplexx Targu Mures este cel mai nou multiplex din oras, dotat cu cele mai avansate tehnologii de imagine si sunet din lume: Dolby Atmos, RealD Silver Screen si proiector cu laser."
                        },
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
                            FullName = "Dylan O'Brien",   //Dylan O'Brien
                            Bio = "This is the Bio of Dylan O'Brien",
                            ProfilePictureURL = "",

                        },
                        new Actor()
                        {
                            FullName = "Kim Min-gue",   //Kim Min-gue
                            Bio = "This is the Bio of Kim Min-gue",
                            ProfilePictureURL = ""
                        },
                        new Actor()
                        {
                            FullName = "Joseph Gordon-Levitt",  //Joseph Gordon-Levitt
                            Bio = "This is the Bio of Joseph Gordon-Levitt",
                            ProfilePictureURL = ""
                        },
                        new Actor()
                        {
                            FullName = "Selena Gomez",  //Selena Gomez
                            Bio = "This is the Bio of Selena Gomez",
                            ProfilePictureURL = ""
                },
                         new Actor()
                        {
                            FullName = "Thomas Brodie-Sangster",  //Joseph Gordon-Levitt
                            Bio = "This is the Bio of Thomas Brodie-Sangster",
                            ProfilePictureURL = ""
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
                            FullName = "Bong Joon-ho",  //Parasites
                            Bio = "Bio",
                            ProfilePictureURL = ""
                        },
                        new Producer()
                        {
                            FullName = "Wes Ball",  //The Maze Runner
                            Bio = "Bio",
                            ProfilePictureURL = ""
                        },
                        new Producer()
                        {
                            FullName = "Robert Zemeckis",  //The Walk
                            Bio = "Bio",
                            ProfilePictureURL = ""
                        },
                        new Producer()
                        {
                            FullName = "Alice Dewey",  //Hotel Transyilvania 4
                            Bio = "Bio",
                            ProfilePictureURL = ""
                        },
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "The Maze Runner",
                            Description = "This is the Maze Runner description",
                            Price = 29.50,
                            ImageURL = "",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.science_fiction  //science fiction
                        },
                        new Movie()
                        {
                            Name = "Parasites",
                            Description = "description",
                            Price = 39.50,
                            ImageURL = "",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 2,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "The Walk",
                            Description = "description",
                            Price = 39.50,
                            ImageURL = "",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Drama
                        },
                        new Movie()
                        {
                            Name = "Hotel Transylvania 4",
                            Description = "This is Hotel Transylvania 4 movie description",
                            Price = 39.50,
                            ImageURL = "",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 3,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Cartoon
                        },
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 1
                        },
                        /**/

                        

                         new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 2
                        },
                         

                          /**/
                           

                                new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 3
                        },
                                /**/
                        
                         
                           new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                    });
                    context.SaveChanges();
                }

            }
        }
    }
}
