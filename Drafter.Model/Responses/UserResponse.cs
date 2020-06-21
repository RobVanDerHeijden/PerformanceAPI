namespace Drafter.Model.Responses
{
    public class UserResponse : Response<User>
    {
        public UserResponse(User user) : base(user)
        {

        }

        public UserResponse(string message) : base(message)
        {

        }
    }
}