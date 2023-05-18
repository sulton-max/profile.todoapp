namespace TodoApp.Api.Brokers.DateTime;

public interface IDateTimeBroker
{
    DateTimeOffset GetCurrentDateTime();
}