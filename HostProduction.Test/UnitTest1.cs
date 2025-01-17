using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HostProduction.Contracts;
using HostProduction.Controllers;
using HostProduction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

// Namespace zale¿ny od Twojej aplikacji
public class EquipmentPlacementContractsControllerTests
{
	private readonly Mock<IEquipmentPlacementContractsRepository> _repositoryMock;
	private readonly Mock<ILogger<EquipmentPlacementContractsController>> _loggerMock;
	private readonly EquipmentPlacementContractsController _controller;

	public EquipmentPlacementContractsControllerTests()
	{
		_repositoryMock = new Mock<IEquipmentPlacementContractsRepository>();
		_loggerMock = new Mock<ILogger<EquipmentPlacementContractsController>>();
		_controller = new EquipmentPlacementContractsController(null, _repositoryMock.Object, _loggerMock.Object);
	}

	[Fact]
	public async Task Index_ReturnsViewResultWithListOfContracts()
	{
		// Arrange
		var contracts = new List<EquipmentPlacementContractVM>
		{
			new EquipmentPlacementContractVM
			{
				Id = 1,
				EquipmentQuantity = 10,
				ProductionFacilityVM = new ProductionFacilityVM { Id = 1, Name = "Facility1" },
				ProcessEquipmentTypeVM = new ProcessEquipmentTypeVM { Id = 1, Name = "Type1" }
			}
		};

		_repositoryMock
			.Setup(repo => repo.GetEquipmentPlacementContractVMsAsync())
			.ReturnsAsync(contracts);

		// Act
		var result = await _controller.Index();

		// Assert
		var viewResult = Assert.IsType<ViewResult>(result);
		var model = Assert.IsAssignableFrom<IEnumerable<EquipmentPlacementContractVM>>(viewResult.Model);
		Assert.Single(model);
		Assert.Equal("Facility1", model.First().ProductionFacilityVM.Name);
	}

	[Fact]
	public async Task Create_GET_ReturnsViewResultWithCreateVM()
	{
		// Arrange
		var createVM = new EquipmentPlacementContractCreateVM();
		_repositoryMock
			.Setup(repo => repo.GetEquipmentPlacementContractCreateVMAsync())
			.ReturnsAsync(createVM);

		// Act
		var result = await _controller.Create();

		// Assert
		var viewResult = Assert.IsType<ViewResult>(result);
		var model = Assert.IsType<EquipmentPlacementContractCreateVM>(viewResult.Model);
		Assert.NotNull(model);
	}

	[Fact]
	public async Task Create_POST_InvalidModel_ReturnsCreateView()
	{
		// Arrange
		var createVM = new EquipmentPlacementContractCreateVM
		{
			ProductionFacilityId = 1,
			ProcessEquipmentTypeId = 1,
			EquipmentQuantity = 0 // Invalid, powinno byæ > 0
		};

		_repositoryMock
			.Setup(repo => repo.GetEquipmentPlacementContractCreateVMAsync())
			.ReturnsAsync(createVM);

		_controller.ModelState.AddModelError("EquipmentQuantity", "Equipment Quantity cannot be less or equal to 0.");

		// Act
		var result = await _controller.Create(createVM);

		// Assert
		var viewResult = Assert.IsType<ViewResult>(result);
		var model = Assert.IsType<EquipmentPlacementContractCreateVM>(viewResult.Model);
		Assert.Equal(createVM, model);
	}

	[Fact]
	public async Task Create_POST_ValidModel_RedirectsToIndex()
	{
		// Arrange
		var createVM = new EquipmentPlacementContractCreateVM
		{
			ProductionFacilityId = 1,
			ProcessEquipmentTypeId = 1,
			EquipmentQuantity = 5,
			RemainingArea = 50
		};

		_repositoryMock
			.Setup(repo => repo.GetRemainingFacilityAreaAsync(createVM))
			.ReturnsAsync(45); // Simulacja dostêpnej powierzchni

		_repositoryMock
			.Setup(repo => repo.CreateEquipmentPlacementContractAsync(createVM))
			.Returns(Task.CompletedTask);

		// Act
		var result = await _controller.Create(createVM);

		// Assert
		var redirectResult = Assert.IsType<RedirectToActionResult>(result);
		Assert.Equal("Index", redirectResult.ActionName);
	}
}
