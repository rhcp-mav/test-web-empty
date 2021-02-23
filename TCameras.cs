using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace test_web_empty
{
    public class TCameras
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] 
        public bool IsDetected { get; set; }
        
        public int? CameraGroupId { get; set; } // foregin key (name = navigation property + keyId)
        //public TCameraGroups CameraGroup { get; set; } // navigation property
    }
}
