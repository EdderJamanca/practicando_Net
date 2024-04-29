using Api_version2.Models;
using Api_version2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_version2.Controllers;

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

    public IActionResult Post(Tarea tarea){
        TareaService.Save(tarea);
        return Ok();
    }

    public IActionResult Put(Guid id, [FromBody] Tarea tarea){
           TareaService.Update(id, tarea);
           return Ok();
    }

    public IActionResult Delete(Guid id){
        TareaService.Delete(id);
        return Ok();
    }
}