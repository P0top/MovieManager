﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Models;

namespace MovieManager.Pages.Movies
{
	[Authorize]
    public class IndexModel : PageModel
    {
        private readonly MovieManager.Data.MovieManagerContext _context;

        public IndexModel(MovieManager.Data.MovieManagerContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
			var movies = from m in _context.Movie
						 select m;
			if (!string.IsNullOrEmpty(SearchString))
			{
				movies = movies.Where(s => s.Title.Contains(SearchString));
			}

			Movie = await movies.ToListAsync();
        }

		[BindProperty(SupportsGet = true)]
		public string? SearchString { get; set; }

		public SelectList? Genres { get; set; }

		[BindProperty(SupportsGet = true)]
		public string? MovieGenre { get; set; }
	}
}
