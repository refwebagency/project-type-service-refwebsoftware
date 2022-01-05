using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectTypeService.Data;
using ProjectTypeService.Dtos;
using ProjectTypeService.Models;
using ProjectTypeService.SyncDataServices.Http;

namespace ProjectTypeService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProjectTypeController : ControllerBase
    {
        private readonly IProjectTypeRepo _repository;

        private readonly ITemplateDataClient _templateDataClient;

        private readonly IMapper _mapper;
    

        public ProjectTypeController(IProjectTypeRepo repository, IMapper mapper, ITemplateDataClient templateDataClient)
        {
            _repository = repository;
            _mapper = mapper;
            _templateDataClient = templateDataClient;
        }

        /**Pour mettre en forme des résulat de GetAllProjectTypes, 
        pour avoir tous les types de projet sous forme de liste
        de type Dto
        */
        [HttpGet]
        public ActionResult<IEnumerable<ProjectTypeReadDto>> GetAllProjectTypes()
        {
            //Console.WriteLine est équivalent à console.log
            Console.WriteLine("GetProjectTypes");

            var ProjectTypeItem = _repository.GetAllProjectTypes();

            //Retourne un statut 200, qui affiche le resultat
            return Ok(_mapper.Map<IEnumerable<ProjectTypeReadDto>>(ProjectTypeItem));
        }

        //Pour retourner un objet par L'id
        [HttpGet("{id}", Name = "GetProjectTypeById")]
        public ActionResult<ProjectTypeReadDto> GetProjectTypeById(int id)
        {
            var ProjectTypeItem = _repository.GetProjectTypeById(id);

            if(ProjectTypeItem != null)
            {
            return Ok(_mapper.Map<ProjectTypeReadDto>(ProjectTypeItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<ProjectTypeReadDto> CreateProjectType(ProjectTypeCreateDto createProjectTypeDto)
        {
            var projectTypeModel = _mapper.Map<ProjectType>(createProjectTypeDto);

            _repository.CreateProjectType(projectTypeModel);
            //sauvegarde les changements au niveau des données
            _repository.SaveChanges();

            var readProjectTypeDto = _mapper.Map<ProjectTypeReadDto>(projectTypeModel);

            try
            {
                _templateDataClient.SendProjectTypeToTemplate(readProjectTypeDto);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Erreur: " + ex.Message);
            }

            //reourne une route qui renvoie avec un type de project specifique
            return CreatedAtRoute(nameof(GetProjectTypeById), new { Id = readProjectTypeDto.Id }, readProjectTypeDto);
        }

        //Pour modifier un type de projet par son id
        //declaration d'une variable qui récupere comme valeur 
        //le resulat de la méthode GetProjectTypeById, qui elle même
        // se trouve dans le repository ProjectTypeRepos.cs
        [HttpPut("{id}", Name = "UpdateProjectType")]
        public ActionResult<ProjectTypeReadDto> UpdateProjectType(int id, ProjectTypeUpdateDto updateProjectTypeDto)
        {
            var projectTypeModelFromRepo = _repository.GetProjectTypeById(id);
            _mapper.Map(updateProjectTypeDto, projectTypeModelFromRepo);
            if (projectTypeModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.UpdateProjectType(id);
            _repository.SaveChanges();
            
            return CreatedAtRoute(nameof(GetProjectTypeById), new { Id = updateProjectTypeDto.Id }, updateProjectTypeDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProjectTypeById(int id)
        {
            var projectId = _repository.GetProjectTypeById(id);
            if (projectId != null)
            {
                _repository.DeleteProjectTypeById(projectId.Id);
                _repository.SaveChanges();
                return Ok();
            }else{
                return NotFound();
            }
        }
    }
}