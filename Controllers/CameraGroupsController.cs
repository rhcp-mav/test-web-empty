using Microsoft.AspNetCore.Http;
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
    public class CameraGroupsController : ControllerBase
    {
        DataContext db;
        public CameraGroupsController(DataContext context)
        {
            db = context;
        }
        /// <summary>
        /// Get all the camera groups.
        /// </summary>
        /// GET: api/CameraGroupsController/GetAllCameraGroups
        [HttpGet("GetAllCameraGroups")]
        public async Task<ActionResult<IEnumerable<TCameraGroups>>> Get()
        {
            List<TCameraGroups> groups = await db.CameraGroups.ToListAsync();
            if ((groups == null) || (groups.Count == 0))
                return NotFound();
            return groups;
        }
        /// <summary>
        /// Get a camera group by the camera group Id.
        /// </summary>
        /// GET api/CameraGroupsController/GetCameraGroupById/5
        [HttpGet("GetCameraGroupById/{id}")]
        public async Task<ActionResult<TCameraGroups>> GetById(int id)
        {
            TCameraGroups group = await db.CameraGroups.FirstOrDefaultAsync(x => x.Id == id);
            if (group == null)
                return NotFound();
            return new ObjectResult(group);
        }
        /// <summary>
        /// Get a camera group by the camera group name.
        /// </summary>
        [HttpGet("GetCameraGroupByName/{GroupName}")]
        public async Task<ActionResult<IEnumerable<TCameraGroups>>> GetCameraGroupByName(string GroupName)
        {
            return await Task.Run(() =>
            {
                var gr = from g in db.CameraGroups
                         where g.Name == GroupName
                         select g;
                if (gr == null)
                    NotFound();
                return new ObjectResult(gr);
            });
        }
        /// <summary>
        /// Add the camera group.
        /// </summary>
        /// POST api/CameraGroupsController/AddCameraGroup
        [HttpPost("AddCameraGroup")]
        public async Task<ActionResult<TCameraGroups>> Post(TCameraGroups group)
        {
            if (group == null)
            {
                return BadRequest();
            }
            db.CameraGroups.Add(group);
            await db.SaveChangesAsync();
            return Ok(group);
        }

        /// <summary>
        /// Update the camera group.
        /// </summary>
        // PUT api/CameraGroupsController/UpdateCamera
        [HttpPut("UpdateCameraGroup")]
        public async Task<ActionResult<TCameraGroups>> Put(TCameraGroups group)
        {
            if (group == null)
            {
                return BadRequest();
            }
            if (!db.CameraGroups.Any(x => x.Id == group.Id))
            {
                return NotFound();
            }
            db.Update(group);
            await db.SaveChangesAsync();
            return Ok(group);
        }

        /// <summary>
        /// Delete the camera group by Id.
        /// </summary>
        /// DELETE api/CameraGroupsController/DeleteCameraById/5
        [HttpDelete("DeleteCameraGroupById/{id}")]
        public async Task<ActionResult<TCameraGroups>> Delete(int id)
        {
            TCameraGroups group = await db.CameraGroups.FirstOrDefaultAsync(x => x.Id == id);
            if (group == null)
                return NotFound();
            var cams = from c in db.Cameras
                            where c.CameraGroupId == id
                            select c;
            foreach (TCameras cam in cams)
            {
                cam.CameraGroupId = null;
                db.Cameras.Update(cam);
            }
            await db.SaveChangesAsync();

            db.CameraGroups.Remove(group);
            await db.SaveChangesAsync();
            return Ok(group);
        }

    }
}
