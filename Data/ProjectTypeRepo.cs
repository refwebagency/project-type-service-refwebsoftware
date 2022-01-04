using System.Linq;
using System;
using System.Collections.Generic;
using ProjectTypeService.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectTypeService.Data
{
    public class ProjectTypeRepo : IProjectTypeRepo
    {
        private readonly AppDbContext _context;

        public ProjectTypeRepo(AppDbContext context)
        {
            _context = context;
        }

        /**
        * Creation d'un type de projet 
        * si type de projet n'est pas null alors add pour creer avec projectType en parametre
        * sauvegarde les changements
        * sinon erreur
        */

        public void CreateProjectType(ProjectType projectType)
        {
            if(projectType != null)
            {
            //_context.Projects equivaut a bdd.Projects
            _context.projectType.Add(projectType);
            _context.SaveChanges();
            }
        }

            /**
        * Je passe un type de project à mon IEnumerable
        * je veux qu'il me retourne suivant le context les types de projects sous forme de liste
        */
        public IEnumerable<ProjectType> GetAllProjectTypes()
        {
            return _context.projectType.ToList();
        }

        /**
        * je veux qu'il me retourne suivant le context un type project par l'id de type int
        * ça va me récuperé le premier ou par default
        * c'est à dire le projectType.id qui est == à l'id qui est en paramètres
        */
        public ProjectType GetProjectTypeById(int id)
        {
            return _context.projectType.FirstOrDefault(p => p.Id == id);
        }

        /**
        *Pour update un projet je doit en premier le récupere par son id 
        *puis je le modifie par son état
        */
        public void UpdateProjectType(int id)
        {
            var projectTypeId = _context.projectType.Find(id);
            _context.Entry(projectTypeId).State = EntityState.Modified;
        }

        public void DeleteProjectTypeById(int id)
        {
            var projectTypeItem = _context.projectType.Find(id);
            if(projectTypeItem != null)
            {
                _context.projectType.Remove(projectTypeItem);
            }
            
        }

        /**
        * Pour sauvegarder les changements si dans le context
        * les changements sont >= à 0
        */

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0 );
        }  
    }
}