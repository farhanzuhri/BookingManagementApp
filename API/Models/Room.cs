using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{


    //membuat anotasi tabel dengan nama custom
    [Table("tb_m_rooms")]
    public class Room : BaseEntity
    {
        //tidak boleh null, kolom dinamai dan tipe data spesifik
        [Required, Column("name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        //tidak boleh null dan kolom dinamai
        [Required, Column("floor")]
        public int Floor { get; set; }
        //tidak boleh null dan kolom dinamai 
        [Required, Column("capacity")]
        public int Capacity { get; set; }

        //cardinality
        public ICollection<Booking>? Bookings { get; set; }
    }
}
