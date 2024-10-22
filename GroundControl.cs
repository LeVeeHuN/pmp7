namespace PmP_7;

public class GroundControl
{
    private List<Flight> _flights = new List<Flight>();
    private DateTime _currentTime = DateTime.Now;

    public void AddFlight(Flight flight)
    {
        _flights.Add(flight);
    }

    public double AverageDelay()
    {
        int summarizedDelay = 0;
        int nonCanceledFlights = 0;
        foreach (Flight flight in _flights)
        {
            if (flight.CurrentStatus != Status.Cancelled)
            {
                summarizedDelay += flight.DelayInMinutes;
                nonCanceledFlights++;
            }
        }
        return (double)summarizedDelay / nonCanceledFlights;
    }

    public void DisplayFlightData()
    {
        foreach (Flight flight in _flights)
        {
            Console.WriteLine(flight.AllData());
        }

        Console.WriteLine($"Average delay is {Math.Round(AverageDelay(), 2)} minutes.");
    }
}