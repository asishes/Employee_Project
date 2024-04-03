namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLOYEE")]
    public partial class EMPLOYEE
    {
        [Key]
        public int EMP_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string EMP_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string EMP_DESCRIPTION { get; set; }

        public int EMP_AGE { get; set; }

        public long EMP_SALARY { get; set; }

        [Column(TypeName = "date")]
        public DateTime EMP_JOINDATE { get; set; }
    }
}
