using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{

    [Table(name: "tb_m_accounts")]
    public class Account : BaseEntity 
    {

        [Column(name: "password"), MaxLength(100)]
        public string Password { get; set; }
        [Column(name: "is_deleted")]
        public bool IsDeleted { get; set; }
        [Column(name: "otp")]
        public int Otp {  get; set; }
        [Column(name: "isused")]
        public bool IsUsed { get; set; }
        [Column(name: "expired_date")]
        public DateTime ExpiredDate { get; set; }
       
    }
}
