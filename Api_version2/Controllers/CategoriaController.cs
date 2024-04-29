

// using Microsoft.AspNetCore.Components;
// using Api_version2.Service;
using Api_version2.Models;
using Api_version2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_version2.Controllers;

[Route("api/[controller]")]
public class CategoriaController : ControllerBase 
{
   ICategoriaService categoriaService;

   public CategoriaController(ICategoriaService service){
       categoriaService=service;
   }

   [HttpGet]
   public IActionResult Get(){
      return Ok(categoriaService.Get());
   }

   [HttpPost]

   public IActionResult Post([FromBody] Categoria categoria){
    categoriaService.Save(categoria);
    return Ok();
   }

   [HttpPut]
   public IActionResult Put(Guid id, [FromBody] Categoria categoria)
   {
    categoriaService.Update(id,categoria);
    return Ok();
   }

   [HttpDelete]
   public IActionResult Delete(Guid id){
    categoriaService.Delete(id);
    return Ok();
   }
}