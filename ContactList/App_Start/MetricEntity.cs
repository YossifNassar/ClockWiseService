using Microsoft.WindowsAzure.Storage.Table;

namespace ContactList
{
    public class MetricEntity : TableEntity
    {
        public MetricEntity(int SleepCycle, int HeartRate)
        {
            this.PartitionKey = SleepCycle.ToString();
            this.RowKey = HeartRate.ToString();
        }
          
        public MetricEntity() { }

        public int SleepCycle { get; set; }

        public int HeartRate { get; set; }
    }
}