
using Microsoft.AspNetCore.Mvc;
using sacraldotnet.DTO;
using sacraldotnet.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sacraldotnet.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IDatabaseService _databaseService;
        private readonly IEmailService _emailService;
        private readonly IFtpService _ftpService;
        private readonly ISharepointService _sharepointService;
        private readonly ITimerService _timerService;

        public ReportController(
            IReportService reportService,
            IDatabaseService databaseService,
            IEmailService emailService,
            IFtpService ftpService,
            ISharepointService sharepointService,
            ITimerService timerService)
        {
            _reportService = reportService;
            _databaseService = databaseService;
            _emailService = emailService;
            _ftpService = ftpService;
            _sharepointService = sharepointService;
            _timerService = timerService;
        }

        [HttpPost("ConfigureReportDelivery")]
        public async Task<IActionResult> ConfigureReportDelivery([FromBody] ReportDeliveryOptions options)
        {
            await _reportService.ConfigureReportDelivery(options.FileType, options.Destination, options.Frequency);
            return Ok();
        }

        [HttpGet("FetchVendorsBySector/{sector}")]
        public async Task<IActionResult> FetchVendorsBySector(string sector)
        {
            List<Vendor> vendors = await _databaseService.GetVendorsBySectorAsync(sector);
            return Ok(vendors);
        }

        [HttpPost("GenerateReport")]
        public async Task<IActionResult> GenerateReport([FromBody] GenerateReportOptions options)
        {
            byte[] reportData = await _reportService.GenerateReport(options.Vendors);
            switch (options.Destination)
            {
                case "email":
                    await _emailService.SendEmailWithAttachmentAsync(options.Recipient, options.Subject, options.Body, reportData, options.FileType);
                    break;
                case "ftp":
                    await _ftpService.UploadFileAsync(options.FtpUrl, options.Username, options.Password, reportData, options.FileType);
                    break;
                case "sharepoint":
                    await _sharepointService.UploadFileAsync(options.SharepointUrl, options.Username, options.Password, reportData, options.FileType);
                    break;
                default:
                    return BadRequest("Invalid destination");
            }
            return Ok();
        }

        [HttpGet("FetchRequests")]
        public async Task<IActionResult> FetchRequests()
        {
            await _reportService.FetchRequestInformation();
            return Ok();
        }

        [HttpGet("FetchSchedule")]
        public async Task<IActionResult> FetchSchedule()
        {
            await _reportService.FetchScheduleInformation();
            return Ok();
        }

        [HttpGet("StartTimer")]
        public async Task<IActionResult> StartTimer()
        {
            await _timerService.Delay(60000);
            await _reportService.FetchScheduleInformation();
            return Ok();
        }
    }
}
