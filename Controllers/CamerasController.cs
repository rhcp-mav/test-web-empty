using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace test_web_empty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamerasController : ControllerBase
    {
        // --- next step
        //private readonly ILogger<CamerasController> _logger;
        //public CamerasController(ILogger<CamerasController> logger)
        //{
        //    _logger = logger;
        //}

        DataContext db;
        public CamerasController(DataContext context)
        {
            db = context;
        }
        /// <summary>
        /// Get all the cameras.
        /// </summary>
        /// GET: api/CamerasController/GetAllCameras
        [HttpGet("GetAllCameras")]
        public async Task<ActionResult<IEnumerable<TCameras>>> Get()
        {
            List<TCameras> cameras = await db.Cameras.ToListAsync();
            if ((cameras == null) || (cameras.Count == 0))
                return NotFound();
            return cameras;
        }
        /// <summary>
        /// Get a camera by the camera Id.
        /// </summary>
        /// GET api/CamerasController/GetCameraById/5
        [HttpGet("GetCameraById/{id}")]
        public async Task<ActionResult<TCameras>> GetCameraById(int id)
        {
            TCameras camera = await db.Cameras.FirstOrDefaultAsync(x => x.Id == id);
            if (camera == null)
                return NotFound();
            return new ObjectResult(camera);
        }
        /// <summary>
        /// Get the cameras by the camera group name.
        /// </summary>
        /// GET api/CamerasController/GetCamerasByCameraGroupName/group-001
        [HttpGet("GetCamerasByCameraGroupName/{name}")]
        public async Task<ActionResult<IEnumerable<TCameras>>> GetCamerasByCameraGroupName(string name)
        {
            var cams = from g in db.CameraGroups
                     join c in db.Cameras on g.Id equals c.CameraGroupId
                     where g.Name == name
                     select c;
            if ((cams == null) || (cams.Count() == 0))
                return NotFound();
            return new ObjectResult(cams);
        }
        /// <summary>
        /// Add the camera.
        /// </summary>
        /// POST api/CamerasController/AddCamera
        [HttpPost("AddCamera")]
        public async Task<ActionResult<TCameras>> Post(TCameras camera)
        {
            if(camera == null)
            {
                return BadRequest();
            }
            db.Cameras.Add(camera);
            await db.SaveChangesAsync();
            return Ok(camera);
        }
        /// <summary>
        /// Add some cameras to the camera group by the camera group Id.
        /// </summary>
        /// POST api/CameraGroupsController/AddCamerasToCameraGroup
        [HttpPost("AddCamerasToCameraGroup/{CameraGroupId}")]
        public async Task<ActionResult<IEnumerable<TCameras>>> AddCamerasToCameraGroup(List<TCameras> cams, int CameraGroupId)
        {
            if ((cams == null) || (cams.Count() == 0))
            {
                return BadRequest();
            }
            TCameraGroups group = await db.CameraGroups.FirstOrDefaultAsync(x => x.Id == CameraGroupId);
            if (group == null)
            {
                return BadRequest();
            }
            List<TCameras> result = new List<TCameras>();
            foreach (TCameras c in cams)
            {
                TCameras cam = await db.Cameras.FirstOrDefaultAsync(x => x.Id == c.Id);
                if (cam != null)
                {
                    cam.CameraGroupId = CameraGroupId;
                    db.Update(cam);
                    result.Add(cam);
                }
            }
            db.SaveChanges();
            //=============================================== 
            //JsonSerializerOptions options = new()
            //{
            //    ReferenceHandler = ReferenceHandler.Preserve,
            //    WriteIndented = true
            //};
            //string res = JsonSerializer.Serialize(result.ToList(), options);
            //================================================
            return result;
        }
        /// <summary>
        /// Update the camera.
        /// </summary>
        // PUT api/CamerasController/UpdateCamera
        [HttpPut("UpdateCamera")]
        public async Task<ActionResult<TCameras>> Put(TCameras camera)
        {
            if (camera == null)
            {
                return BadRequest();
            }
            if(!db.Cameras.Any(x => x.Id == camera.Id))
            {
                return NotFound();
            }
            db.Update(camera);
            await db.SaveChangesAsync();
            return Ok(camera);
        }

        /// <summary>
        /// Deletes the camera.
        /// </summary>
        /// DELETE api/CamerasController/DeleteCameraById/5
        [HttpDelete("DeleteCameraById/{id}")]
        public async Task<ActionResult<TCameras>> Delete(int id)
        {
            TCameras camera = await db.Cameras.FirstOrDefaultAsync(x => x.Id == id);
            if (camera == null)
                return NotFound();
            db.Cameras.Remove(camera);
            await db.SaveChangesAsync();
            return Ok(camera);
        }
    }
}
