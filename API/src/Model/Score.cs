using System.ComponentModel.DataAnnotations;

namespace API.Model;

public class Score {
    public int Id {get;set;}
    [Required]
    public String UserName {get;set;} = null!;
    [Required]
    public float Highscore {get;set;}
}
