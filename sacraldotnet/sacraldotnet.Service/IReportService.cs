public interface IReportService
{
    Task ConfigureReportDelivery(string fileType, string destination, string frequency);
    Task FetchRequestInformation();
    Task FetchScheduleInformation();
    Task StartTimer();
}

public interface IDatabaseService
{
    Task<List<Vendor>> GetVendorsBySectorAsync(string sector);
}

public interface IEmailService
{
    Task SendEmailWithAttachmentAsync(string recipient, string subject, string body, byte[] attachmentData, string fileType);
}

public interface IFtpService
{
    Task UploadFileAsync(string ftpUrl, string username, string password, byte[] fileData, string fileType);
}

public interface ISharepointService
{
    Task UploadFileAsync(string sharepointUrl, string username, string password, byte[] fileData, string fileType);
}

public interface ITimerService
{
    Task Delay(int milliseconds);
}

public interface IVendor
{
    string Name { get; set; }
    string Address { get; set; }
    string Email { get; set; }
}