using System;
using System.Threading.Tasks;
using Chuck.API.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using Dapper;

namespace Chuck.API.Repository
{
    public class DapperRepo : IDapper
    {

        private readonly IConfiguration _config;

        private readonly ILogger<DapperRepo> _log;

        private const string ChuckByJokeLevel = "sp_read_chuck_jokes_by_joke_level";

        private const string ChuckJokeRandom  = "sp_read_chuck_jokes_randomly"; 


        public DapperRepo(IConfiguration config,ILogger<DapperRepo> log)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _log = log ?? throw new ArgumentNullException(nameof(config));
        }

        public  async Task<ChuckNorrisJokes> GetChuckNorrisJokeAsync(int? funnyLevel = null)
        {   
            try
            {
                var storeProc = funnyLevel is null ? ChuckJokeRandom : ChuckByJokeLevel;
                using(var con = new SqlConnection(_config.GetConnectionString("ChuckCon")))
                {
                    var result = await con.QueryFirstAsync<ChuckNorrisJokes>(storeProc, funnyLevel, commandType: System.Data.CommandType.StoredProcedure);
                    return result;
                }
            }
            catch(Exception ex)
            {
                this._log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
    }


}