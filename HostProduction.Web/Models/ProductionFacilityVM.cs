namespace HostProduction.Models
{
	public class ProductionFacilityVM
	{
		public int? Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public decimal StandardArea { get; set; }
		public decimal RemainingArea { get; set; }
		public ProductionFacilityVM()
		{
			RemainingArea = StandardArea;
		}
	}
}
