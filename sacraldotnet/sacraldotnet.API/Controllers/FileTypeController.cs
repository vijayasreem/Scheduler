
using Microsoft.AspNetCore.Mvc;
using sacraldotnet.DTO;
using sacraldotnet.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sacraldotnet.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileTypeController : ControllerBase, IFileTypeController
    {
        private readonly IReportGenerator _reportGenerator;
        private readonly IFileTypeService _fileTypeService;

        public FileTypeController(IReportGenerator reportGenerator, IFileTypeService fileTypeService)
        {
            _reportGenerator = reportGenerator;
            _fileTypeService = fileTypeService;
        }

        [HttpGet]
        public async Task<List<FileType>> GetFileTypes(string keyword)
        {
            return await _fileTypeService.GetFileTypes(keyword);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class NotificationConfigurationController : ControllerBase, INotificationConfigurationController
    {
        private readonly INotificationConfigurationService _notificationConfigurationService;

        public NotificationConfigurationController(INotificationConfigurationService notificationConfigurationService)
        {
            _notificationConfigurationService = notificationConfigurationService;
        }

        [HttpGet]
        public async Task<NotificationConfiguration> GetNotificationConfiguration()
        {
            return await _notificationConfigurationService.GetNotificationConfiguration();
        }

        [HttpPost]
        public async Task UpdateNotificationConfiguration(NotificationConfiguration configuration)
        {
            await _notificationConfigurationService.UpdateNotificationConfiguration(configuration);
        }
    }
}
