using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IsracardServer.Models;
using IsracardServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace IsracardServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _host;

        private FilesService _fileService = new FilesService();
        // GET: api/Task

        public TaskController(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
            _host = _httpContextAccessor.HttpContext.Request.Host.Value;

        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var tasks = TasksServiceSingleton.Instance.GetTasks();
                return Ok(tasks);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }


        // POST: api/Task
        [HttpPost]
        public ActionResult Post([FromForm] UploadTaskModel task)
        {
            try
            {
                if (_fileService.UploadFile(task.FileName, task.FormFile,_env, _host, out string path))
                {
                    CustomTask newTask = new CustomTask(path, task.Text);
                    TasksServiceSingleton.Instance.AddTask(newTask);
                    return StatusCode(StatusCodes.Status201Created, newTask);
                }
                else
                {
                    //file name already exist
                    return Conflict("File alreay exist");
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in file uploading");
            }

        }


        // PUT: api/Task/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
