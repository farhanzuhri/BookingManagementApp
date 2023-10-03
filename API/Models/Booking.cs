using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{

    //membuat anotasi tabel dengan nama custom
    [Table(name: "tb_m_bookings")]
    public class Booking : BaseEntity
    {
        //tidak boleh null dan kolom dinamai
        [Required, Column("start_date")]
        public DateTime StartDate { get; set; }
        [Required, Column("end_date")]
        public DateTime EndDate { get; set; }
        //tidak boleh null dan kolom dinamai
        [Required, Column("status")]
        public StatusLevel Status { get; set; }
        //tidak boleh null, kolom dinamai dan tipe data spesifik
        [Required, Column("remarks", TypeName = "nvarchar")]
        public string Remarks { get; set; }
        //tidak boleh null dan kolom dinamai
        [ForeignKey("Room"), Column("room_guid")]
        public Guid RoomGuid { get; set; }
        //tidak boleh null dan kolom dinamai
        [ForeignKey("Employee"), Column("employee_id")]
        public Guid EmployeeGuid { get; set; }

        // Cardinality
        public Employee? Employee { get; set; }
        public Room? Room { get; set; }
        

    }
}
