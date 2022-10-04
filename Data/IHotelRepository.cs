
public interface IHotelRepository : IDisposable
{
    Task<List<Hotel>> GetHotelsAsync();
    Task<Hotel> GetHotelAsync(int hotelId);
    Task InsertHotelsAsync(Hotel hotel);
    Task UpdateHotelsAsync(Hotel hotel);
    Task DeleteHotelsAsync(int hotelId);
    Task SaveAsync();
}
