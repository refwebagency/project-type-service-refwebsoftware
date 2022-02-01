using ProjectTypeService.Dtos;

namespace ProjectTypeService.AsyncDataClient
{
    public interface IMessageBusClient
    {
        void UpdatedProjectType(ProjectTypeUpdateAsyncDto projectTypeUpdateAsyncDto);
    }
}