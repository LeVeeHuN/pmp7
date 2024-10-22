namespace PmP_7;

public class Flight
{
    private string _flightNo;
    private string _destination;
    private DateTime _scheduledDeparture;
    private int _delayInMinutes;
    private Status _currentStatus;
    
    public string FlightNo { get { return _flightNo; } }
    public string Destination { get { return _destination; } }
    public DateTime ScheduledDeparture { get { return _scheduledDeparture; } }
    public int DelayInMinutes { get { return _delayInMinutes; } }
    public Status CurrentStatus { get { return _currentStatus; } }

    public Flight(string flightNo, string destination, DateTime scheduledDeparture, int delayInMinutes)
    {
        _flightNo = flightNo;
        _destination = destination;
        _scheduledDeparture = scheduledDeparture;
        _delayInMinutes = delayInMinutes;
        if (delayInMinutes > 0) _currentStatus = Status.Delayed;
        else _currentStatus = Status.Scheduled;
    }
    
    public Flight(string flightNo, string destination, DateTime scheduledDeparture)
    {
        _flightNo = flightNo;
        _destination = destination;
        _scheduledDeparture = scheduledDeparture;
        _delayInMinutes = 0;
        _currentStatus = Status.Scheduled;
    }

    private void UpdateStatus(Status status)
    {
        _currentStatus = status;
    }
    
    private void UpdateStatus()
    {
        // _currentStatus = _delayInMinutes == 0 ? Status.Scheduled : Status.Delayed;
        if (_delayInMinutes > 0) _currentStatus = Status.Delayed;
        else _currentStatus = Status.Scheduled;
    }
    

    public void Delay(int minutes)
    {
        _delayInMinutes = minutes;
        UpdateStatus();
    }

    public void Cancel()
    {
        UpdateStatus(Status.Cancelled);
    }

    public string AllData()
    {
        string strToRet = $"Flight {FlightNo} is ";
        switch (CurrentStatus)
        {
            case Status.Scheduled:
                strToRet += $"on time. (STD {ScheduledDeparture.ToShortDateString()} {ScheduledDeparture.ToShortTimeString()})";
                break;
            case Status.Delayed:
                strToRet += $"is delayed by {DelayInMinutes} minutes. (ETD {EstimatedDeparture().ToShortDateString()}"+
                            $" {EstimatedDeparture().ToShortTimeString()})";
                break;
            case Status.Cancelled:
                strToRet += $"is canceled.";
                break;
        }
        return strToRet;
    }

    public DateTime EstimatedDeparture()
    {
        return ScheduledDeparture.AddMinutes(DelayInMinutes);
    }
}