namespace HostProduction.Models
{
	public class EquipmentPlacementContractVM
	{
		public int? Id { get; set; }
		public int ProductionFacilityId { get; set; }
		public int ProcessEquipmentTypeId { get; set; }
		public int EquipmentQuantity { get; set; }
	}
}
