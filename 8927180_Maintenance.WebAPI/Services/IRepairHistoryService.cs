namespace _8927180_Maintenance.WebAPI.Services
{
    public interface IRepairHistoryService
    {
        List<RepairHistoryDTO> GetByVehicleId(int vehicleId);
    }
}