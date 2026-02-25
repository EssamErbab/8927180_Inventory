namespace _8927180_Maintenance.WebAPI.Services
{
    public interface IRepairHistoryService
    {
        IEnumerable<RepairHistoryDTO> GetAll();
		IEnumerable<RepairHistoryDTO> GetByVehicleId(int vehicleId);
        RepairHistoryDTO AddRepair(RepairHistoryDTO repair);
	}
}