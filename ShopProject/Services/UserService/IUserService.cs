namespace ShopProject.Services.UserService
{
    public interface IUserService
    {
        User? Login(UserLogin userLogin);
        void Create(UserRegister userRegister);

    }
}
