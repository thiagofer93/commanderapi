using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepository _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(_repository.GetAll()));
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<CommandReadDto> GetById(int id)
        {
            var command = _repository.GetById(id);

            if (command != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(command));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> Create(CommandCreateDto dto)
        {
            var model = _mapper.Map<Command>(dto);
            _repository.Create(model);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetById), new { Id = model.Id }, _mapper.Map<CommandReadDto>(model));
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, CommandUpdateDto dto)
        {
            var model = _repository.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, model);
            _repository.Update(model);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<CommandUpdateDto> patch)
        {
            var model = _repository.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(model);
            patch.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, model);
            _repository.Update(model);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var model = _repository.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            _repository.Delete(model);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}