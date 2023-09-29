using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace API.Models
{
    //membuat anotasi tabel dengan nama custom
    [Table(name: "tb_m_employees")]
    public class Employee : BaseEntity 
    {

        //tidak boleh null, kolom dinamai dan tipe data spesifik
        [Required, Column("nik", TypeName = "nchar(6)")]
        public string NIK { get; set; }
        //tidak boleh null, kolom dinamai dan tipe data spesifik
        [Required, Column("first_name", TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        //tidak boleh null, kolom dinamai dan tipe data spesifik
        [Column("last_name", TypeName = "nvarchar(100)")]
        public string? LastName { get; set; }
        //tidak boleh null dan kolom dinamai
        [Required, Column("birth_date")]
        public DateTime BirthDate { get; set; }
        //tidak boleh null dan kolom dinamai 
        [Required, Column("gender")]
        public Gender Gender { get; set; }
        //tidak boleh null dan kolom dinamai 
        [Required, Column("hiring_date")]
        public DateTime HiringDate { get; set; }
        //tidak boleh null, kolom dinamai dan tipe data spesifik
        [Required, Column("email", TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        //tidak boleh null, kolom dinamai dan tipe data spesifik
        [Required, Column("phone_number", TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }

        // Cardinality
        public Education? Education { get; set; }
        public Account? Account { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        

    }
}
