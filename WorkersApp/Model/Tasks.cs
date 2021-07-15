namespace WorkersApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tasks
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string TaskCategory { get; set; }

        [StringLength(255)]
        public string TaskDescription { get; set; }

        public int? WorkerID { get; set; }

        public virtual Workers Workers { get; set; }
    }
}
