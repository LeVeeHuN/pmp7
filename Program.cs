namespace PmP_7;

class Program
{
    static void Main(string[] args)
    {
        GroundControl gc1 = new GroundControl();
        gc1.AddFlight(new Flight("LH1337", "Budapest", new DateTime(2024, 10, 20, 11, 10, 00)));
        gc1.AddFlight(new Flight("W62221", "Budapest", new DateTime(2024, 10, 20, 11, 50, 00)));
        gc1.AddFlight(new Flight("FR3586", "Budapest", new DateTime(2024, 10, 20, 16, 05, 00)));
        
        GroundControl gc2 = new GroundControl();
        gc2.AddFlight(new Flight("LH1337", "Budapest", new DateTime(2024, 10, 20, 11, 10, 00), 30));
        Flight f = new Flight("W62221", "Budapest", new DateTime(2024, 10, 20, 16, 05, 00));
        f.Cancel();
        gc2.AddFlight(f);
        gc2.AddFlight(new Flight("FR3586", "Budapest", new DateTime(2024, 10, 20, 16, 05, 00)));
        
        gc1.DisplayFlightData();
        gc2.DisplayFlightData();
            
    }
}