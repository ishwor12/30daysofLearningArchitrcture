Details of project structure.

RestaurantManagement
│
├── Controllers/
│     MenuController.cs
│     OrderController.cs
│     TableController.cs
│
├── Data/
│     ApplicationDbContext.cs
│     Migrations/
│
├── Models/
│   ├── Entities/
│   │     MenuItem.cs
│   │     Order.cs
│   │     Table.cs
│   └── Enums/
│         OrderStatus.cs
│         TableStatus.cs
│     
│
├── Repositories/
│   ├── Interfaces/
│   │     IGenericRepository.cs
│   │     IMenuItemRepository.cs   
│   ├── Implementation/
│         GenericRepository.cs
│         MenuItemRepository.cs
│
├── Services/
│   ├── Interfaces/
│   │     IMenuItemService.cs
│   ├── Implementation/
│         MenuItemService.cs
│
├── Views/
│     Home/
│     Menu/
│     Order/
│     Table/
│Shared View
| _Layout
└── Program.cs

