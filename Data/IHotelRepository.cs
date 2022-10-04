
public interface IHotelRepository : IDisposable
{
    Task<List<Hotel>> GetHotelsAsync();
    Task<List<Hotel>> GetHotelsAsync(string name);
    Task<Hotel> GetHotelAsync(int hotelId);
    Task InsertHotelsAsync(Hotel hotel);
    Task UpdateHotelsAsync(Hotel hotel);
    Task DeleteHotelsAsync(int hotelId);
    Task SaveAsync();
}
