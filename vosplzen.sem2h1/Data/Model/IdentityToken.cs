using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace vosplzen.sem2h1.Data.Model
{
    public class IdentityToken
    {


        [Key]
        public int Id { get; set; }

        [MaxLength(360)]
        public string Token { get; set; }   
        public DateTime ValidTo { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }
      
    }
}
