using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using HostProduction.Contracts;

namespace HostProduction.Models
{
	public class EquipmentPlacementContractCreateVM : IValidatableObject
	{
		public int? Id { get; set; }

		[Required]
		[Display(Name = "Production Facility Code")]
		public int ProductionFacilityId { get; set; }
		public SelectList? AvailableProductionFacilities { get; set; }

		[Required]
		[Display(Name = "Process Equipment Code")]
		public int ProcessEquipmentTypeId { get; set; }
		public SelectList? AvailableProcessEquipmentTypes { get; set; }

		[Required]
		[Display(Name = "Equipment Quantity")]
		public int EquipmentQuantity { get; set; }

		public decimal RemainingArea { get; set; }



		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (EquipmentQuantity <= 0)
			{
				yield return new ValidationResult(
					"Equipment Quantity cannot be less or equal to 0.",
					new[] {nameof(EquipmentQuantity)}
					);
			}

			if (RemainingArea < 0)
			{
				yield return new ValidationResult(
					"Not enough space in this Facility to fit these Process Equipments",
					new[] { nameof(RemainingArea) }
					);
			}
		}

	}
}

