public class HotelRepository : IHotelRepository
{
    private readonly HotelDb _context;

    public HotelRepository(HotelDb context)
    {
        _context = context;
    }

    public async Task<List<Hotel>> GetHotelsAsync() => await _context.Hotels.ToListAsync();

    public async Task<Hotel> GetHotelAsync(int hotelId) => await _context.Hotels.FindAsync(new object[]{hotelId});

    public async Task InsertHotelsAsync(Hotel hotel) => await _context.Hotels.AddAsync(hotel);

    public async Task UpdateHotelsAsync(Hotel hotel)
    {
        var hotelFromDb = await _context.Hotels.FindAsync(new object[]{hotel.Id});
        if (hotelFromDb == null) return;

        hotelFromDb.Latitude = hotel.Latitude;
        hotelFromDb.Longitude = hotel.Longitude;
        hotelFromDb.Name = hotel.Name;
    }

    public async Task DeleteHotelsAsync(int hotelId)
    {
        var hotelFromDb = await _context.Hotels.FindAsync(new object[]{hotelId});
        if (hotelFromDb == null) return;

        _context.Hotels.Remove(hotelFromDb);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    private bool _disposed = false;
    protected virtual void Dispose(bool disposing) 
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}