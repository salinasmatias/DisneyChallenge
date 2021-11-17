using AutoMapper;
using DisneyWorld.Domain.Dtos;
using DisneyWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyWorld.AccessData.Commands
{
    public class UserRepository : IUserRepository
    {
        private readonly DisneyWorldContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DisneyWorldContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(User user)
        {
            this._context.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User usuario)
        {
            _context.Remove(usuario);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var user = GetUserById(id);
            Delete(user);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(user => user.Email == email);
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public User GetUsuarioByEmailAndPassword(string email, string password)
        {
            return _context.Users.SingleOrDefault(User => User.Email == email && User.Password == password);
        }

        public void Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
