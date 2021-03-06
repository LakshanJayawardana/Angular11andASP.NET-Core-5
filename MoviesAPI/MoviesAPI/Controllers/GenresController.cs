using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using MoviesAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")] //Genres Controller so Genres is the controllers
    [ApiController]
     public class GenresController: ControllerBase
    {
       
       private readonly ILogger<GenresController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenresController(ILogger<GenresController> logger,
            ApplicationDbContext context,IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

      
       // [HttpGet("list")]  //api/genres/list

        [HttpGet] //api/genres
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            logger.LogInformation("Getting all the genres");

            var genres = await context.Genres.ToListAsync();

            return mapper.Map<List<GenreDTO>>(genres);

        }

        [HttpGet("{Id:int}", Name = "getGenre")] //api/genres/example
        public ActionResult<Genre> Get(int Id)
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public async  Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            context.Add(genre);
            await context.SaveChangesAsync();
            return NoContent();
        }



        [HttpPut]
        public ActionResult Put([FromBody] Genre genre)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }








    }
}
