using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;

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
                            Name = "Cinema One",   //Cinema One Brasso
                            Logo = "https://www.fest.ro/files/places/11/image_1199_1_large.jpg",
                            Description = "Cinema One Brașov este destinația ideală pentru cinefilii" +
                                            " care doresc să își petreacă timpul liber într-o atmosferă deosebită." +
                                            " Aici pot fi vizionate cele mai noi filme, într-un spațiu creat special" +
                                            " pentru pasionații de film și spectacol."
                        },
                        new Cinema()
                        {
                            Name = "Cinema City",   //Cinema City Maros
                            Logo = "https://cdn-ukwest.onetrust.com/logos/5922c8a7-c44a-4864-9773-804dd97f3b15/f34055f9-6c0b-4d74-8bbd-5408ead3b445/c6feb110-9eb7-4055-be06-409f0d2c5223/CCrounded.png",
                            Description = "Cinema City este cel mai mare operator de cinema din România şi face parte" +
                            " din Cineworld Group, al doilea mare lanţ de cinema din Europa."
                        },
                        new Cinema()
                        {
                            Name = "Cineplexx",   //Cineplexx Maros
                            Logo = "https://s3proxygw.cineplexx.at/vapc-ro-pimcore/assets/_default_upload_bucket/89339725_136908084528296_2319869874186223616_n_3.jpg",
                            Description = "Cineplexx Targu Mures este cel mai nou multiplex din oras, dotat" +
                            " cu cele mai avansate tehnologii de imagine si sunet din lume: Dolby Atmos, RealD Silver" +
                            " Screen si proiector cu laser."
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
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/0/08/Dylan_O%27Brien_2014_%28cropped%29.jpg",

                        },
                        new Actor()
                        {
                            FullName = "Kim Min-gue",   //Kim Min-gue
                            Bio = "This is the Bio of Kim Min-gue",
                            ProfilePictureURL = "https://contents.pep.ph/images2/images2/2023/03/17/kim-min-kyu-main-image-1679053995.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Joseph Gordon-Levitt",  //Joseph Gordon-Levitt
                            Bio = "This is the Bio of Joseph Gordon-Levitt",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Joseph_Gordon-Levitt_2013.jpg/399px-Joseph_Gordon-Levitt_2013.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Selena Gomez",  //Selena Gomez
                            Bio = "This is the Bio of Selena Gomez",
                            ProfilePictureURL = "https://api.time.com/wp-content/uploads/2020/09/time-100-Selena-Gomez.jpg"
                },
                         new Actor()
                        {
                            FullName = "Thomas Brodie-Sangster",  //Joseph Gordon-Levitt
                            Bio = "This is the Bio of Thomas Brodie-Sangster",
                            ProfilePictureURL = "https://www.tvinsider.com/wp-content/uploads/2022/11/thomas-brodie-sangster-1014x570.jpg"
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
                            ProfilePictureURL = "https://variety.com/wp-content/uploads/2020/02/bong-joon-ho-2.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Wes Ball",  //The Maze Runner
                            Bio = "Bio",
                            ProfilePictureURL = "https://static.kinoafisha.info/k/persons/220/upload/persons/173324718740.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Robert Zemeckis",  //The Walk
                            Bio = "Bio",
                            ProfilePictureURL = "https://images.squarespace-cdn.com/content/v1/5c62c09c4d546e27dc1016c7/1557234323360-GEZ7ILIM1IC410AF2C4B/bio_robert-zemeckis.jpg"
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
                            ImageURL = "https://w0.peakpx.com/wallpaper/817/577/HD-wallpaper-maze-runner-the-maze-runner-thomas.jpg",
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
                            ImageURL = "https://wallpapercave.com/wp/wp5510260.jpg",
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
                            ImageURL = "https://e1.pxfuel.com/desktop-wallpaper/213/802/desktop-wallpaper-the-walk-movie-hq-the-walk-the-walk.jpg",
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
                            ImageURL = "https://wallpapercave.com/wp/wp9510951.jpg",
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

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
				if (!await roleManager.RoleExistsAsync(UserRoles.User))
					await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

				//Users
				var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var adminUser = await userManager.FindByEmailAsync("admin@etickets.com");
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin",
                        Email = "admin@etickets.com",
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");  //create a user
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                //
				var appUser = await userManager.FindByEmailAsync("user@etickets.com");
				if (appUser == null)
				{
					var newAppUser = new ApplicationUser()
					{
						FullName = "Applicaion User",
						UserName = "app-user",
						Email = "user@etickets.com",
						EmailConfirmed = true
					};
					await userManager.CreateAsync(newAppUser, "Coding@1234?");  //create a user
					await userManager.AddToRoleAsync(newAppUser, UserRoles.User);

				}

			}
        }
    }
}
