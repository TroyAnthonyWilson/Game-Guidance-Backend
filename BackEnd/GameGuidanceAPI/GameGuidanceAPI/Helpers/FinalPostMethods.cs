//using Microsoft.Identity.Client;
//using GameGuidanceAPI.Models.IGDB;
//using GameGuidanceAPI.Models;
//using GameGuidanceAPI.Context;
//using GameGuidanceAPI.Controllers;

//namespace GameGuidanceAPI.Helpers
//{
//    public class FinalPostMethods
//    {
//        public int userGameMode;
//        public int userGenre;
//        public int userPlayerPerspective;
//        public int userTheme;
//        public List<int> userIgnoreId;
//        public List<string> userPlatforms = new List<string>() {"where platforms=6", "where platforms=(34,39)", 
//            "where platforms=(165,163,162,390,388)", "where platforms!=(6,34,39,165,163,162,390,388)",""};
//        private GameGuidanceDBContext _authContext;


//        //Method to provide correct platforms based on user input
//        //public string GenerateCorrectPlatforms()
//        //{
//        //    if (Choice.Platform == 0)
//        //    {
//        //        return userPlatforms[0];
//        //    }
//        //    if (Choice.Platform == 1)
//        //    {
//        //        return userPlatforms[1];
//        //    }
//        //    if (Choice.Platform == 2)
//        //    {
//        //        return userPlatforms[2];
//        //    }
//        //    if (Choice.Platform == 3)
//        //    {
//        //        return userPlatforms[3];
//        //    }
//        //    if (Choice.Platform == 4)
//        //    {
//        //        return userPlatforms[4];
//        //    }
//        //}

//        public string GenerateFinalPost()
//        {
//            string finalPost = $"fields *; where game_modes=({userGameMode}); where genres=({userGenre}); " +
//                $"where player_perspectives=({userPlayerPerspective}); where themes=({userTheme}); where category=(0,8,9,11); where status=0; " +
//                $"where id!=({userIgnoreId});";
//            return finalPost;
//        }
//    }
//}
