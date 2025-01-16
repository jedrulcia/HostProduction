using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostProduction.Data
{
	public class ProductionFacility
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public decimal StandardArea { get; set; }
	}
}
