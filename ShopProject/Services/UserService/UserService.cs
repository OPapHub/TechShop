using Microsoft.Extensions.Logging.Abstractions;
using ShopProject.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace ShopProject.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _db;
        public UserService(DataContext db)
        {
            _db = db;
        }

        public void Create(UserRegister userRegister)
        {
            CreatePasswordHash(userRegister.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User();
            user.Username = userRegister.Username;
            user.FirstName = userRegister.FirstName;
            user.LastName = userRegister.LastName;
            user.Email = userRegister.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _db.Users.Add(user);

            _db.SaveChanges();
        }

        public User? Login(UserLogin userLogin)
        {
            if(string.IsNullOrEmpty(userLogin.Username) || string.IsNullOrEmpty(userLogin.Password))
            {
                return null;
            }

            var user = _db.Users.FirstOrDefault(x => x.Username == userLogin.Username);
            if(user is null)
            {
                return null;
            }
            //var user = _db.Users.FirstOrDefault(x => x.Username == userLogin.Username && x.Password == userLogin.Password);
            
            if(!VerifyPassword(userLogin.Password,user.PasswordHash,user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}
