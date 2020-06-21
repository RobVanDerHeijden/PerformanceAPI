namespace Drafter.Model.Responses
{
    public class TeamResponse : Response<Team>
    {
        public TeamResponse(Team team) : base(team)
        {

        }

        public TeamResponse(string message) : base(message)
        {

        }
    }
}