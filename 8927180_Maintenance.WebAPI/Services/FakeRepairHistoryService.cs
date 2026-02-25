namespace _8927180_Maintenance.WebAPI.Services
{
    public class FakeRepairHistoryService : IRepairHistoryService
    {
        private List<RepairHistoryDTO> RepairHistory = new()
        {
            new RepairHistoryDTO
            {
                Id = 1,
                VehicleId = 1,
                RepairDate = DateTime.Now.AddDays(-10),
                Description = "Oil change",
                Cost = 89.99m,
                PerformedBy = "Quick Lube"
            },
            new RepairHistoryDTO
            {
                Id = 2,
                VehicleId = 2,
                RepairDate = DateTime.Now.AddDays(-40),
                Description = "Brake pad replacement",
                Cost = 350.00m,
                PerformedBy = "Auto Repair Pro"
            },
            new RepairHistoryDTO
            {
                Id = 3,
                VehicleId = 2,
                RepairDate = DateTime.Now.AddDays(-40),
                Description = "Brake pad replacement",
                Cost = 350.00m,
                PerformedBy = "Auto Repair Pro"
			},
			new RepairHistoryDTO
			{
				Id = 4,
				VehicleId = 1,
				RepairDate = DateTime.Now.AddDays(-40),
				Description = "Brake pad replacement",
				Cost = 350.00m,
				PerformedBy = "Auto Repair Pro"
			}
		};

        private int nextId()
        {
            int maxId = RepairHistory.Count > 0 ? RepairHistory.Max(r => r.Id) : 0;
            return maxId + 1;
		}

        public IEnumerable<RepairHistoryDTO> GetAll() => RepairHistory;

		public IEnumerable<RepairHistoryDTO> GetByVehicleId(int vehicleId) => RepairHistory.Where(r => r.VehicleId == vehicleId);

		public RepairHistoryDTO AddRepair(RepairHistoryDTO repair)
        {
            repair.Id = nextId();
            RepairHistory.Add(repair);
			return repair;
		}

	}
}