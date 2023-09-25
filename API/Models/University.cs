using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{

    //membuat anotasi tabel dengan nama custom
    [Table("tb_m_university")]
    public class University : BaseEntity
    {
        //tidak boleh null, kolom dinamai dan tipe data spesifik
        [Required, Column("code", TypeName = "nvarchar(50)")]
        public string Code { get; set; }
        //tidak boleh null, kolom dinamai dan tipe data spesifik
        [Required, Column("name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }
    }
}
