using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public OrderRepository(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<List<OrderDto>>> GetOrder()
        {
            ServiceResponse<List<OrderDto>> response = new ServiceResponse<List<OrderDto>>();
            List<Order> orders = await _context.Orders.Where(o => o.UserId == GetUserId())
                .Include(ord => ord.Items)
                .ToListAsync();

            var mapped = orders.Select(o => _mapper.Map<OrderDto>(o)).ToList();    
            response.Data = mapped;
            return response;
        }
        public async Task<ServiceResponse<List<OrderDto>>> PlaceOrder(Order newOrder)
        {
            ServiceResponse<List<OrderDto>> response = new ServiceResponse<List<OrderDto>>();
            List<Order> orders = await _context.Orders.Where(o => o.UserId == GetUserId())
                .Include(o => o.Items)
                .ToListAsync();
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            Cart cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == GetUserId());
            Order order = new Order {
                User = user,
                Cost = newOrder.Cost,
                Items = cart.Items,
                Address = newOrder.Address,
                ContactEmail = newOrder.ContactEmail,
                ContactPhone = newOrder.ContactPhone
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            var mapped = orders.Select(o => _mapper.Map<OrderDto>(o)).ToList();    
            response.Data = mapped;
            return response;
        }
    }
}