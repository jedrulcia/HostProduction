using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HostProduction.Data;
using HostProduction.Contracts;
using HostProduction.Models;
using HostProduction.Repositories;

namespace HostProduction.Controllers
{
	public class EquipmentPlacementContractsController : Controller
	{
		private readonly ApplicationDbContext context;
		private readonly IEquipmentPlacementContractsRepository equipmentPlacementContractsRepository;

		public EquipmentPlacementContractsController(ApplicationDbContext context, IEquipmentPlacementContractsRepository equipmentPlacementContractsRepository)
		{
			this.context = context;
			this.equipmentPlacementContractsRepository = equipmentPlacementContractsRepository;
		}

		// GET: EquipmentPlacementContracts
		public async Task<IActionResult> Index()
		{
			return View(await equipmentPlacementContractsRepository.GetEquipmentPlacementContractVMsAsync());
		}

		// GET: EquipmentPlacementContracts/Create
		public async Task<IActionResult> Create()
		{
			return View(await equipmentPlacementContractsRepository.GetEquipmentPlacementContractCreateVMAsync());
		}

		// POST: EquipmentPlacementContracts/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(EquipmentPlacementContractCreateVM equipmentPlacementContractCreateVM)
		{
			equipmentPlacementContractCreateVM.RemainingArea = await equipmentPlacementContractsRepository
				.GetRemainingFacilityAreaAsync(equipmentPlacementContractCreateVM);

			if (!TryValidateModel(equipmentPlacementContractCreateVM))
			{
				TempData["ErrorMessage"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault()
					?? "Error during creation on Equipment Placement Contract. Try again.";
				return View(await equipmentPlacementContractsRepository.GetEquipmentPlacementContractCreateVMAsync());
			}
			try
			{
				await equipmentPlacementContractsRepository.CreateEquipmentPlacementContractAsync(equipmentPlacementContractCreateVM);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				TempData["ErrorMessage"] = "Error during creation on Equipment Placement Contract. Try again.";
				return View(await equipmentPlacementContractsRepository.GetEquipmentPlacementContractCreateVMAsync());
			}
		}
	}
}
