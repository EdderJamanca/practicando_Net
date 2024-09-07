using Api_version2.Models;
using Api_version2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_version2.Controllers;

[Route("api/[controller]")]
public class TareaController:ControllerBase
{
    ITareaService TareaService;

    public TareaController(ITareaService service){
        TareaService=service;
    }

    [HttpGet]
    public ActionResult Get(){
        return Ok(TareaService.Get());
    }
    [HttpPost]
    public IActionResult Post(Tarea tarea){
        TareaService.Save(tarea);
        return Ok("se registro de forma exitosa");
    }
    [HttpPut]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea){
           TareaService.Update(id, tarea);
           return Ok();
    }
    [HttpPut]
    public IActionResult Delete(Guid id){
        TareaService.Delete(id);
        return Ok();
    }
}