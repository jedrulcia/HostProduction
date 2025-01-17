using System.Collections.Generic;
using System.Threading.Tasks;
using HostProduction.Contracts;
using HostProduction.Controllers;
using HostProduction.Models;
using HostProduction.Test;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Xunit;

public class EquipmentPlacementContractsControllerTests
{
	[Fact]
	public async Task Index_ReturnsViewWithModel()
	{
		var repositoryStub = new EquipmentPlacementContractsRepositoryStub
		{
			EquipmentPlacementContracts = new List<EquipmentPlacementContractVM>
			{
				new EquipmentPlacementContractVM
				{
					Id = 1,
					ProductionFacilityVM = new ProductionFacilityVM { Id = 1, Code = "FAC001", StandardArea = 1000.00m, RemainingArea = 900.00m },
					ProcessEquipmentTypeVM = new ProcessEquipmentTypeVM { Id = 1, Code = "EQP001", Name = "Equipment1", Area = 70.00m },
					EquipmentQuantity = 2
				},
				new EquipmentPlacementContractVM
				{
					Id = 2,
					ProductionFacilityVM = new ProductionFacilityVM { Id = 2, Code = "FAC002", StandardArea = 1500.00m, RemainingArea = 1200.00m },
					ProcessEquipmentTypeVM = new ProcessEquipmentTypeVM { Id = 2, Code = "EQP002", Name = "Equipment2", Area = 20.00m },
					EquipmentQuantity = 3
				},
				new EquipmentPlacementContractVM
				{
					Id = 3,
					ProductionFacilityVM = new ProductionFacilityVM { Id = 3, Code = "FAC003", StandardArea = 100.00m, RemainingArea = 50.00m },
					ProcessEquipmentTypeVM = new ProcessEquipmentTypeVM { Id = 3, Code = "EQP003", Name = "Equipment3", Area = 50.00m },
					EquipmentQuantity = 5
				}
			}
		};

		var controller = new EquipmentPlacementContractsController(repositoryStub);
		var result = await controller.Index();

		var viewResult = Assert.IsType<ViewResult>(result);
		var model = Assert.IsType<List<EquipmentPlacementContractVM>>(viewResult.Model);
		Assert.Equal(3, model.Count);
	}

	[Fact]
	public async Task Create_GET_ReturnsViewWithModel()
	{
		var repositoryStub = new EquipmentPlacementContractsRepositoryStub
		{
			EquipmentPlacementContractCreateVM = new EquipmentPlacementContractCreateVM
			{
				AvailableProductionFacilities = new SelectList(new List<ProductionFacilityVM>
				{
					new ProductionFacilityVM { Id = 1, Code = "FAC001", RemainingArea = 900m },
					new ProductionFacilityVM { Id = 2, Code = "FAC002", RemainingArea = 500m }
				}, "Id", "Code"),
				AvailableProcessEquipmentTypes = new SelectList(new List<ProcessEquipmentTypeVM>
				{
					new ProcessEquipmentTypeVM { Id = 1, Code = "EQP001", Area = 70m },
					new ProcessEquipmentTypeVM { Id = 2, Code = "EQP002", Area = 50m }
				}, "Id", "Code")
			}
		};

		var controller = new EquipmentPlacementContractsController(repositoryStub);
		var result = await controller.Create();

		var viewResult = Assert.IsType<ViewResult>(result);
		var model = Assert.IsType<EquipmentPlacementContractCreateVM>(viewResult.Model);
		Assert.NotNull(model.AvailableProductionFacilities);
		Assert.NotNull(model.AvailableProcessEquipmentTypes);
	}

	[Fact]
	public async Task Create_POST_RedirectsToIndexOnSuccess()
	{
		var repositoryStub = new EquipmentPlacementContractsRepositoryStub();
		var controller = new EquipmentPlacementContractsController(repositoryStub);

		var validVm = new EquipmentPlacementContractCreateVM
		{
			ProductionFacilityId = 1,
			ProcessEquipmentTypeId = 1,
			EquipmentQuantity = 3
		};

		var result = await controller.Create(validVm);

		var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
		Assert.Equal("Index", redirectToActionResult.ActionName);
	}
}
