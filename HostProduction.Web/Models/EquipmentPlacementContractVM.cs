using System.ComponentModel.DataAnnotations;

namespace HostProduction.Models
{
	public class EquipmentPlacementContractVM
	{
		public int? Id { get; set; }
		[Display(Name = "Production Facility")]
		public ProductionFacilityVM ProductionFacilityVM { get; set; }
		[Display(Name = "Process Equipment Type")]
		public ProcessEquipmentTypeVM ProcessEquipmentTypeVM { get; set; }
		[Display(Name = "Equipment Quantity")]
		public int EquipmentQuantity { get; set; }
	}
}
