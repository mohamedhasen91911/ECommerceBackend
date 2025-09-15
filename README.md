# 🛒 E-Commerce Backend API (ASP.NET Core 8)

Backend project for an **E-commerce platform** built with **ASP.NET Core 8** and **Entity Framework Core (Code-First)**.  
Implements **Clean Architecture** with Repository & Service layers, and supports **JWT Authentication**.  

---

## 🚀 Project Status
📍 **Phase 1 (MVP) Completed**  
This is the first milestone of the project. It includes all the **core backend features** of an e-commerce system.  
Upcoming phases will add more advanced features and improvements.

---

## ✨ Features (Phase 1)
- 👤 **User Management**
  - Register & Login with JWT Authentication
  - Roles: Customer, Merchant, Admin
- 🛍 **Products**
  - CRUD operations
  - Linked to Categories & Brands
- 📂 **Categories & Brands**
  - Manage product categories and brands
- 🛒 **Shopping Cart & Wishlist**
  - Add/remove products
  - Manage customer cart & wishlist
- ⭐ **Featured Products**
  - Admin can mark products as featured
- 📦 **Orders**
  - Create orders with multiple products
  - Order details store quantity & price
- 💳 **Payments**
  - Linked to orders (Card, Wallet, COD)
- 🚚 **Shipping**
  - Address, tracking number, delivery status
- 💬 **Reviews**
  - Customers can review products

---

## 📌 Roadmap
### 🔹 Phase 2
- Role-based Authorization (Admin, Merchant, Customer)  
- Product image upload  
- Automatic stock history updates  
- Pagination, search & filtering  

### 🔹 Phase 3
- Notifications (Email / Push)  
- Multi-language support (EN/AR)  
- Docker & CI/CD pipeline  
- Cloud deployment  

---

## 🛠 Tech Stack
- **ASP.NET Core 8 Web API**
- **Entity Framework Core 8**
- **SQLite** (development DB)
- **JWT Authentication**
- **AutoMapper**
- **Repository + Service Pattern**

---

## 🚀 Getting Started

### 1. Clone Repository
```bash
git clone https://github.com/USERNAME/ECommerceBackend.git
cd ECommerceBackend
```
### 2. Setup Database

Make sure you have Entity Framework Core tools installed.
Then run the following command to apply migrations and create the database:
```bash
dotnet ef database update
```

### 3. Run the API
```bash
dotnet run
```

API will be available at:
👉 https://localhost:5001/swagger

## 📊 Database Diagram
![DB_D_1_EX_2](https://github.com/user-attachments/assets/98e6d294-d304-4bfe-90e0-41e0b3eb8a4c)


## 📸 Demo Screenshots

<img width="2880" alt="screencapture-localhost-5062-swagger-index-html-2025-09-15-21_26_04" src="https://github.com/user-attachments/assets/383dd9fd-0cc7-4606-bd8e-6159ee939fbc" />

## 👤 Author
**Mohamed Hassan**  
🔗 [LinkedIn](https://www.linkedin.com/in/mohamedhasen91911/)  
🐙 [GitHub](https://github.com/mohamedhasen91911)



