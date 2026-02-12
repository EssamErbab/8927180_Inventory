namespace _8927180_Maintnance.WebAPI.Services
{
    public interface IRepairHistoryService
    {
        List<RepairHistoryDTO> GetByVehicleId(int vehicleId);
    }
}