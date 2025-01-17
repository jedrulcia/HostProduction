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
using Microsoft.AspNetCore.Authorization;
using HostProduction.Web.Configurations.Exceptions;

namespace HostProduction.Controllers
{
	[Authorize]
	public class EquipmentPlacementContractsController : Controller
	{
		private readonly IEquipmentPlacementContractsRepository equipmentPlacementContractsRepository;

		public EquipmentPlacementContractsController(IEquipmentPlacementContractsRepository equipmentPlacementContractsRepository)
		{
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
			if (ModelState.IsValid)
			{
				try
				{
					await equipmentPlacementContractsRepository.CreateEquipmentPlacementContractAsync(equipmentPlacementContractCreateVM);
					return RedirectToAction(nameof(Index));
				}
				catch (AreaException)
				{
					TempData["ErrorMessage"] = "Not enough area to place chosen equipment in the facility.";
					return View(await equipmentPlacementContractsRepository.GetEquipmentPlacementContractCreateVMAsync());
				}
				catch
				{
					TempData["ErrorMessage"] = "Error during creation of Contract. Try again.";
					return View(await equipmentPlacementContractsRepository.GetEquipmentPlacementContractCreateVMAsync());
				}
			}
			TempData["ErrorMessage"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault()
				?? "Error during creation of Contract. Try again.";
			return View(await equipmentPlacementContractsRepository.GetEquipmentPlacementContractCreateVMAsync());
		}
	}
}
