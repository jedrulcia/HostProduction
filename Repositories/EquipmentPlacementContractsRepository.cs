﻿using AutoMapper;
using HostProduction.Contracts;
using HostProduction.Data;
using HostProduction.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HostProduction.Repositories
{
	public class EquipmentPlacementContractsRepository : GenericRepository<EquipmentPlacementContract>, IEquipmentPlacementContractsRepository
	{
		private readonly IMapper mapper;
		private readonly IProcessEquipmentTypeRepository processEquipmentTypeRepository;
		private readonly IProductionFacilityRepository productionFacilityRepository;

		public EquipmentPlacementContractsRepository(ApplicationDbContext context,
			IMapper mapper,
			IProcessEquipmentTypeRepository processEquipmentTypeRepository, 
			IProductionFacilityRepository productionFacilityRepository) : base(context)
		{
			this.mapper = mapper;
			this.processEquipmentTypeRepository = processEquipmentTypeRepository;
			this.productionFacilityRepository = productionFacilityRepository;
		}
		public async Task<List<EquipmentPlacementContractVM>> GetEquipmentPlacementContractVMsAsync()
		{
			var contracts = await GetAllAsync();
			var contractVMs = new List<EquipmentPlacementContractVM>();

			foreach (var contract in contracts)
			{
				var contractVM = mapper.Map<EquipmentPlacementContractVM>(contract);
				contractVM.ProductionFacilityVM = await productionFacilityRepository.GetProductionFacilityVMAsync(contract.ProductionFacilityId);
				contractVM.ProcessEquipmentTypeVM = await processEquipmentTypeRepository.GetProcessEquipmentTypeVMAsync(contract.ProcessEquipmentTypeId);
				contractVMs.Add(contractVM);
			}

			return contractVMs;
		}

		public async Task<EquipmentPlacementContractCreateVM> GetEquipmentPlacementContractCreateVMAsync()
		{

			List<ProcessEquipmentTypeVM> equipmentVMs = await processEquipmentTypeRepository.GetProcessEquipmentTypeVMsAsync();
			List<ProductionFacilityVM> facilityVMs = await productionFacilityRepository.GetProductionFacilityVMsAsync();
			List<EquipmentPlacementContractVM> contractVMs = await GetEquipmentPlacementContractVMsAsync();

			EquipmentPlacementContractCreateVM equipmentPlacementContractCreateVM = new EquipmentPlacementContractCreateVM();
			foreach (var contract in contractVMs)
			{
				var facility = facilityVMs.Where(f => f.Id == contract.ProductionFacilityVM.Id).Single();
				var equipment = equipmentVMs.Where(e => e.Id == contract.ProcessEquipmentTypeVM.Id).Single();

				facility.RemainingArea -= equipment.Area * contract.EquipmentQuantity;
			}

			equipmentPlacementContractCreateVM.AvailableProcessEquipmentTypes = new SelectList(equipmentVMs.OrderBy(e => e.Code), "Id", "Code");
			equipmentPlacementContractCreateVM.AvailableProductionFacilities = new SelectList(facilityVMs.OrderBy(f => f.Code), "Id", "Code");

			return equipmentPlacementContractCreateVM;
		}

		public async Task<decimal> GetRemainingFacilityAreaAsync(EquipmentPlacementContractCreateVM equipmentPlacementContractCreateVM)
		{
			List<EquipmentPlacementContractVM> contractVMs = (await GetEquipmentPlacementContractVMsAsync())
				.Where(x => x.ProductionFacilityVM.Id == equipmentPlacementContractCreateVM.ProductionFacilityId 
				&& x.ProcessEquipmentTypeVM.Id == equipmentPlacementContractCreateVM.ProcessEquipmentTypeId)
				.ToList();

			var facilityVM = await productionFacilityRepository.GetProductionFacilityVMAsync(equipmentPlacementContractCreateVM.ProductionFacilityId);
			var equipmentVM = await processEquipmentTypeRepository.GetProcessEquipmentTypeVMAsync(equipmentPlacementContractCreateVM.ProcessEquipmentTypeId);

			foreach (var contract in contractVMs)
			{
				facilityVM.RemainingArea -= contract.ProcessEquipmentTypeVM.Area * contract.EquipmentQuantity;
			}

			facilityVM.RemainingArea -= equipmentVM.Area * equipmentPlacementContractCreateVM.EquipmentQuantity;

			return facilityVM.RemainingArea;
		}


		public async Task CreateEquipmentPlacementContractAsync(EquipmentPlacementContractCreateVM equipmentPlacementContractCreateVM)
		{
			await AddAsync(mapper.Map<EquipmentPlacementContract>(equipmentPlacementContractCreateVM));
		}
	}
}
