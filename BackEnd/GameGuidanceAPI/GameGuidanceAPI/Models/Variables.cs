using GameGuidanceAPI.Models;

namespace GameGuidanceAPI.Models
{
    //Class to add variables and methods
    public abstract class Variables
    {
        public static Question question = new Question();
        public static string recommendRequest = "";
        //Method to add conditions to the PostRecommend 
        public static void AddParameter(string parameter)
        {
            question.Parameters.Add(parameter);
        }
        //Method to assemble the final string to be used in the Recommend POST Request
        //public string RecommendedPost()
        //{
        //    AddParameter("fields *;");
        //    List<string> parameters = question.Parameters;
        //    User currentUser = new User();
        //    //Adds the question's MinimumRating parameter to the final POST request
        //    if (question.MinimumRating != null)
        //    {
        //        AddParameter($" where minimum_rating={question.MinimumRating}");
        //    }
        //    AddParameter("Excludes themes=42");
        //}
    }
}
