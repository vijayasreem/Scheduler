public interface IReportGenerator
{
    Task GenerateReport(FileType fileType);
}

public interface IReportDeliveryConfiguration
{
    DestinationType DestinationType { get; set; }
    string DestinationAddress { get; set; }

    bool ValidateDestination();
}

public interface IDeliveryScheduler
{
    void ConfigureDeliverySchedule(DeliverySchedule schedule);
    DeliverySchedule GetDeliverySchedule();
}

public interface IFileTypeController
{
    Task<List<FileType>> GetFileTypes(string keyword);
}

public interface INotificationConfiguration
{
    List<string> EmailAddresses { get; set; }
    string Subject { get; set; }
    string BodyText { get; set; }
}

public interface INotificationConfigurationController
{
    Task<NotificationConfiguration> GetNotificationConfiguration();
    Task UpdateNotificationConfiguration(NotificationConfiguration configuration);
}