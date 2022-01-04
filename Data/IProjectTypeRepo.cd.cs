using System.Collections.Generic;
using ProjectTypeService.Models;


namespace ProjectTypeService.Data
{

    //Je definie l'interface IProjectRepo avec ses méthodes, proprietés, indexeurs et évenements à implémenter
    public interface IProjectTypeRepo
    {
        //SaveChanges() permet de sauvegarder les changements dans la base de données
         bool SaveChanges();

         IEnumerable<ProjectType> GetAllProjectTypes(); //Retourne une liste de type de projets

         ProjectType GetProjectTypeById(int projectTypeId); //Obtenir type de projet par id

         void CreateProjectType(ProjectType projectType); //Crer un type de projet

         void UpdateProjectType(int projectId); //Mettre à jour un type de projet

         void DeleteProjectTypeById(int projectId); //Supprimer un type de projet
    }
}