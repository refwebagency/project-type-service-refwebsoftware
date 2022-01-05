using System.Threading.Tasks;
using ProjectTypeService.Dtos;

namespace ProjectTypeService.SyncDataServices.Http
{
    public interface ITemplateDataClient
    {
         Task SendProjectTypeToTemplate(ProjectTypeReadDto projectType);
    }
}