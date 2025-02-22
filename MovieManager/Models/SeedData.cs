using Microsoft.EntityFrameworkCore;
using MovieManager.Data;

namespace MovieManager.Models;

public static class SeedData
{
	public static void Initialize(IServiceProvider serviceProvider)
	{
		using (var context = new MovieManagerContext(
			serviceProvider.GetRequiredService<
				DbContextOptions<MovieManagerContext>>()))
		{
			if (context == null || context.Movie == null)
			{
				throw new ArgumentNullException("Null RazorPagesMovieContext");
			}

			// Look for any movies.
			if (context.Movie.Any())
			{
				return;   // DB has been seeded
			}

			context.Movie.AddRange(
				new Movie
				{
					Title = "Interstellar",
					ReleaseDate = DateTime.Parse("2014-11-7"),
					Genre = "Science fiction Drama",
				},

				new Movie
				{
					Title = "Ghostbusters ",
					ReleaseDate = DateTime.Parse("1984-3-13"),
					Genre = "Comedy",
				},

				new Movie
				{
					Title = "Ghostbusters 2",
					ReleaseDate = DateTime.Parse("1986-2-23"),
					Genre = "Comedy",
				},

				new Movie
				{
					Title = "Back to the Future",
					ReleaseDate = DateTime.Parse("1985-7-3"),
					Genre = "Science fiction",
				}
			);
			context.SaveChanges();
		}
	}
}
