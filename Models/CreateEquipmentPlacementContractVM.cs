using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HostProduction.Models
{
	public class CreateEquipmentPlacementContractVM
	{
		public int? Id { get; set; }

		[Required]
		[Display(Name = "Production Facility Code")]
		public int ProductionFacilityId { get; set; }
		public SelectList? ProductionFacilities { get; set; }

		[Required]
		[Display(Name = "Process Equipment Code")]
		public int ProcessEquipmentTypeId { get; set; }
		public SelectList? ProcessEquipments { get; set; }

		[Required]
		[Display(Name = "Equipment Quantity")]
		public int EquipmentQuantity { get; set; }

		public decimal RemainingArea { get; set; }
		public decimal EquipmentArea { get; set; }
	}
}
