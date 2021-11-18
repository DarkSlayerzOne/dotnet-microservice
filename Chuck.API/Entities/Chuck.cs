using System;

namespace Chuck.API.Entities
{

    public record ChuckNorrisJokes
    {

        public Guid? ID { get; set; }
        
        public string Joke { get; set; }
        
        public int FunnyLevel { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        
    
        public ChuckNorrisJokes(Guid? id, string joke, int funnyLevel, DateTime? createdDate)
        {
            ID = id;
            Joke = joke;
            FunnyLevel = funnyLevel;
            CreatedDate = createdDate;
        }

    }

}