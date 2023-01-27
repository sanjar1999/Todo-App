using Todo_App.Application.Common.Interfaces;

namespace Todo_App.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
