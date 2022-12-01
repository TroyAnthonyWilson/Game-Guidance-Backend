using GameGuidanceAPI.Models;
using System.Reflection.Metadata;

namespace GameGuidanceAPI.Controllers
{
    //Class to add variables and methods
    public abstract class Variables
    {
        public static Question question = new Question();
        public string recommendRequest = "";
        //Method to add conditions to the PostRecommend 
        public static void AddParameter(List<string> parameters, string parameter)
        {
            parameters.Add(parameter);
        }
        //Method to assemble the final string to be used in the Recommend POST Request
        public static string CreateRequest()
        {
            Question question = new Question();
            List<string> parameters = question.Parameters;
            AddParameter(parameters, "fields = *;");
            //Adds the question's MinimumRating parameter to the final POST request
            if (question.MinimumRating != null)
            {
                AddParameter(parameters, $"where aggregated_rating>={question.MinimumRating};");
            }
            if (question.SinglePlayer == true)
            {
                AddParameter(parameters, "where game_modes=(1);");
            }
            if (question.MultiPlayer == true)
            {
                AddParameter(parameters, "where game_modes=(2);");
            }

            AddParameter(parameters, "where themes!=42;");

            string finishedRequest = String.Join(" ", parameters);

            return finishedRequest;
        }
    }
}
