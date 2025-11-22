
using ResturanrtManagement.Models;
using ResturanrtManagement.Repositories.Interfaces;
using ResturanrtManagement.Services.Interfaces;

namespace ResturanrtManagement.Services.Implementation
{

    // The implementation of the business logic for Menu Items
    public class MenuItemService : IMenuItemService
    {
            // Inject the generic repository specifically for MenuItem
            private readonly IGenericRepository<MenuItem> _menuItemRepository;

            // Constructor for dependency injection
            public MenuItemService(IGenericRepository<MenuItem> menuItemRepository)
            {
                _menuItemRepository = menuItemRepository;
            }

            // --- READ Operations ---

            // BLL: Gets all items 
            public async Task<IEnumerable<MenuItem>> GetAllAsync()
            {
                return await _menuItemRepository.GetAllAsync();
            }
        //Or
        //public async Task<IEnumerable<MenuItem>> GetAllAsync() => await _menuItemRepository.GetAllAsync();

        public async Task<MenuItem?> GetByIdAsync(int id) => await _menuItemRepository.GetByIdAsync(id);


        // BLL: Gets only available items (Business Logic: IsAvailable = true)
        public async Task<IEnumerable<MenuItem>> GetAvailableMenuItemsAsync()
            {
                // Uses the FindAsync method to filter items where IsAvailable is true
                return await _menuItemRepository.FindAsync(item => item.IsAvailable);
            }

            // BLL: Gets details for a single item
            public async Task<MenuItem?> GetMenuItemDetailsAsync(int itemId)
            {
                // Uses the GetByIdAsync method for direct primary key lookup
                return await _menuItemRepository.GetByIdAsync(itemId);
            }

            // --- CREATE Operation ---

            public async Task CreateAsync(MenuItem item)
            {
                // 1. Add the entity
                await _menuItemRepository.AddAsync(item);
                // 2. Persist the changes to the database
                await _menuItemRepository.SaveChangesAsync();
            }

            // --- UPDATE Operations ---

            // General update for the controller's Edit POST action
            public async Task UpdateAsync(MenuItem item)
            {
                // Mark the entity as modified
                _menuItemRepository.Update(item);
                await _menuItemRepository.SaveChangesAsync();
            }

            // Specialized update for a specific business process (price change)
            public async Task UpdatePriceAsync(int itemId, decimal newPrice)
            {
                var itemToUpdate = await _menuItemRepository.GetByIdAsync(itemId);
                if (itemToUpdate != null)
                {
                    // Apply the specific business change
                    itemToUpdate.Price = newPrice;
                    _menuItemRepository.Update(itemToUpdate);
                    await _menuItemRepository.SaveChangesAsync();
                }
            }

            // --- DELETE Operation ---

            public async Task DeleteAsync(int itemId)
            {
                var itemToDelete = await _menuItemRepository.GetByIdAsync(itemId);
                if (itemToDelete != null)
                {
                    _menuItemRepository.Remove(itemToDelete);
                    await _menuItemRepository.SaveChangesAsync();
                }
            }

       
    }
    }
