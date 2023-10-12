
using System;
using System.Threading.Tasks;
using sacraldotnet.DTO;

namespace sacraldotnet.Service
{
    public interface IReportConfigurationRepository
    {
        Task<int> CreateAsync(ReportConfigurationModel reportConfig);
        Task<ReportConfigurationModel> GetByIdAsync(int id);
        Task UpdateAsync(ReportConfigurationModel reportConfig);
        Task DeleteAsync(int id);
    }

    public interface IVendorRepository
    {
        Task<VendorModel> GetByIdAsync(int id);
    }

    public interface IFileRepository
    {
        Task<int> CreateAsync(FileModel file);
        Task<FileModel> GetByIdAsync(int id);
        Task UpdateAsync(FileModel file);
        Task DeleteAsync(int id);
    }

    public interface IScheduleRepository
    {
        Task<int> CreateAsync(ScheduleModel schedule);
        Task<ScheduleModel> GetByIdAsync(int id);
        Task UpdateAsync(ScheduleModel schedule);
        Task DeleteAsync(int id);
    }
}
