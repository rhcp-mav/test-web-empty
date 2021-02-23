using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace test_web_empty
{
    public class TCameraGroups
    {
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required] 
        public bool IsDetected { get; set; }
        //public List<TCameras> Cameras { get; set; } = new List<TCameras>();
    }
}
