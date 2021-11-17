using System;
using System.Threading.Tasks;
using Chuck.API.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Chuck.API.Controllers
{

    [Route("api/v1")]
    [ApiController]
    public class ChuckController : ControllerBase
    {

        private readonly IDapper _dapper;

        public ChuckController(IDapper dapper)
        {
            _dapper =dapper ?? throw new ArgumentNullException(nameof(dapper));
            
        }

        [Route("chuck")]
        public async Task<IActionResult> GetChuckNorrisJokes()
        {

            var result = await this._dapper.GetChuckNorrisJokeAsync();
            return Ok(result);

        }

        
        [Route("chuck/{level}")]
        public async Task<IActionResult> GetChuckNorrisJokesByLevel(int level = 1)
        {
            var result = await this._dapper.GetChuckNorrisJokeAsync(level);
            return Ok(result);

        }

    }



}