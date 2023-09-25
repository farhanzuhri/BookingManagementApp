using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{


    [Table(name: "tb_m_rooms")]
    public class Room : BaseEntity
    {

        [Column(name: "floor")]
        public int Floor {  get; set; }
        [Column(name: "capacity")]
        public int Capacity { get; set; }

    }
}
