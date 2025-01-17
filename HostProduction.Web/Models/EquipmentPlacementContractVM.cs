namespace HostProduction.Models
{
	public class EquipmentPlacementContractVM
	{
		public int? Id { get; set; }
		public ProductionFacilityVM ProductionFacilityVM { get; set; }
		public ProcessEquipmentTypeVM ProcessEquipmentTypeVM { get; set; }
		public int EquipmentQuantity { get; set; }
	}
}
