using AutoMapper;
using Microsoft.AspNetCore.Http;
using Phoenix.BusinessManagement.ClientModel.Models.HealthCheck;
using Phoenix.BusinessManagement.Entity.Domain.HealthCheck;
using Phoenix.BusinessManagement.Entity.Utility;
using Phoenix.BusinessManagement.Entity.Resources;
using Phoenix.BusinessManagement.Repository.Core;
using Phoenix.BusinessManagement.Repository.Utility;
using static Phoenix.BusinessManagement.Entity.Utility.AppConstants;

namespace Phoenix.BusinessManagement.Service.Services
{
    public interface IHealthCheckService
    {
        Task<ResponseForList> GetAll(int page, int size, byte statusId, HttpRequest? request);
        Task<HealthCheckDetailVM> GetById(int id);
        Task<ResponseModel> Create(HealthCheckCreateVM model, int createdBy);
        Task<ResponseModel> Update(HealthCheckUpdateVM model, int updatedBy);
        Task<ResponseModel> ModifyStatus(int id, byte statusId, int updatedById);
        Task<int> SaveRecord();
    }

    public class HealthCheckService : IHealthCheckService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HealthCheckService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseForList> GetAll(int page, int size, byte statusId, HttpRequest? request)
        {
            var data = new PaginatedData<HealthCheckListVM>();

            var response = await _unitOfWork.HealthCheckRepository.GetAllAsync();

            data.Data = _mapper.Map<List<HealthCheckListVM>>(response);
            data.TotalRows = response.Count();

            return SPManager.FinalPaginatedResultByNewKey(data, page, size);
        }

        public async Task<HealthCheckDetailVM> GetById(int id)
        {
            var response = await _unitOfWork.HealthCheckRepository.GetAsync(id);
            return _mapper.Map<HealthCheckDetailVM>(response);
        }

        public async Task<ResponseModel> Create(HealthCheckCreateVM model, int createdBy)
        {
            var application = await _unitOfWork.HealthCheckRepository.GetAsync(x => x.Name == model.Name);
            if (application != null)
                return Utilities.GetAlreadyExistMsg("HealthCheck Name ");

            await _unitOfWork.HealthCheckRepository.AddAsync(_mapper.Map<Application>(model));
            await SaveRecord();
            return Utilities.GetSuccessMsg(CommonMessages.SavedSuccessfully, model);
        }

        public async Task<ResponseModel> Update(HealthCheckUpdateVM model, int updatedBy)
        {
            var application = await _unitOfWork.HealthCheckRepository.GetAsync(model.Id);

            if (application == null)
                return Utilities.GetNoDataFoundMsg(CommonMessages.NoDataFound);

            _mapper.Map(model, application);
            await _unitOfWork.HealthCheckRepository.UpdateAsync(application);
            await SaveRecord();

            return Utilities.GetSuccessMsg(CommonMessages.UpdatedSuccessfully, model);
        }

        public async Task<ResponseModel> ModifyStatus(int id, byte statusId, int updatedById)
        {
            var application = await _unitOfWork.HealthCheckRepository.GetAsync(x => x.Id == id);
            if (application == null)
            {
                return Utilities.GetValidationFailedMsg(CommonMessages.DataDoesnotExists);
            }
            /*
            if (application.StatusId == statusId)
            {
                return Utilities.GetErrorMsg(CommonMessages.Already + Enum.GetName(typeof(StatusId), statusId));
            } 
            */
            
            await _unitOfWork.HealthCheckRepository.UpdateAsync(application);
            await SaveRecord();

            return Utilities.GetSuccessMsg(statusId == (byte)StatusId.Delete ? CommonMessages.DeletedSuccessfully : statusId == (byte)StatusId.Active ? CommonMessages.ActivedSuccessfully : CommonMessages.InactivedSuccessfully);

        }

        public async Task<int> SaveRecord()
        {
            return await _unitOfWork.Complete();
        }
    }
}
