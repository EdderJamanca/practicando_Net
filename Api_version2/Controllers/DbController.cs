using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

namespace Api_version2.Controllers;
 
[ApiController]
[Route("api/[controller]")]
 public class DbController:ControllerBase
 {
        TareasContext dbcontext;

    public DbController(TareasContext db)
    {

        dbcontext = db;
    }
    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        // return Ok("sdd");
        dbcontext.Database.EnsureCreated();

        return Ok();
    }
 }