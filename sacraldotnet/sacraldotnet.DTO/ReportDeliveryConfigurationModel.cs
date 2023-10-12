
namespace sacraldotnet
{
    public enum DestinationType
    {
        Email,
        CloudStorage,
        InternalServer
    }

    public enum DeliveryFrequency
    {
        Daily,
        Weekly,
        BiWeekly,
        Monthly
    }

    public class ReportDeliveryConfigurationModel
    {
        public DestinationType DestinationType { get; set; }
        public string DestinationAddress { get; set; }

        public void ValidateDestination()
        {
            // TODO: Implement validation logic for DestinationAddress based on DestinationType
        }
    }

    public class DeliveryScheduleModel
    {
        public DeliveryFrequency Frequency { get; set; }
        public List<DayOfWeek> DeliveryDays { get; set; }
        public DateTime DeliveryTime { get; set; }
    }

    public class FileTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FileTypeController
    {
        public IActionResult GetFileTypes()
        {
            // TODO: Implement logic to retrieve file types and return as JSON array
        }
    }

    public class NotificationConfigurationModel
    {
        public List<string> EmailAddresses { get; set; }
        public string Subject { get; set; }
        public string BodyText { get; set; }
    }
}
