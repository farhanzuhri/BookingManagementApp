using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public abstract class BaseEntity
    {

        //membuat primary key dan menamai kolom
        [Key, Column("guid")]
        public Guid Guid { get; set; }
        //tidak boleh null dan menamai kolom 
        [Required, Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        //tidak boleh null dan menamai kolom 
        [Required, Column("modified_date")]
        public DateTime ModifiedDate { get; set; }

    }
}
