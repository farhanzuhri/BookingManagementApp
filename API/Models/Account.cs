using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    //membuat anotasi tabel dengan nama custom
    [Table(name: "tb_m_accounts")]
    public class Account : BaseEntity 
    {
        //tidak boleh null, menamai kolom dan tipe data spesifik
        [Required, Column(name: "password"), MaxLength(250)]
        public string Password { get; set; }
        //tidak boleh null dan kolom dinamai
        [Required, Column(name: "is_deleted")]
        public bool IsDeleted { get; set; }
        //tidak boleh null dan kolom dinamai
        [Required, Column(name: "otp")]
        public int Otp {  get; set; }
        //tidak boleh null dan kolom dinamai
        [Required, Column(name: "isused")]
        public bool IsUsed { get; set; }
        //tidak boleh null dan kolom dinamai
        [Required, Column(name: "expired_date")]
        public DateTime ExpiredDate { get; set; }

        //cardinality
        public ICollection<AccountRole>? AccountRoles { get; set; }
        public Employee? Employee { get; set; }

    }
}
