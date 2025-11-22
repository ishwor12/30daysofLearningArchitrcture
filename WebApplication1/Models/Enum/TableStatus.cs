namespace ResturanrtManagement.Models.Enum
{
    public enum  TableStatus
    {

        Free,      // Ready for seating
        Seated,    // Occupied by a party
        Reserved,  // Currently reserved but not seated
        NeedsCleaning // The party has left, table needs service
    }
}
