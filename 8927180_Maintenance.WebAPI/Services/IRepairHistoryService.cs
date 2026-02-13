namespace _8927180_maintenance.WebAPI.Services
{
    public interface IRepairHistoryService
    {
        List<RepairHistoryDTO> GetByVehicleId(int vehicleId);
    }
}