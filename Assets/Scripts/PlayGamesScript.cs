/*using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class PlayGamesScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
		PlayGamesPlatform.InitializeInstance(config);
		PlayGamesPlatform.Activate ();

		if (!Social.localUser.authenticated) {
			SignIn ();
		}
	}

	void SignIn(){
		Social.localUser.Authenticate ((bool success) => {
			
		});
	}

	#region Archievments
	public static void UnlockAchievement(string id){
		Social.ReportProgress (id, 100, success => {});
	}

	public static void IncrementAchievement(string id, int stepsToIncrement){
		PlayGamesPlatform.Instance.IncrementAchievement (id, stepsToIncrement, success => {
		});
	}

	public static void ShowArchievmentsUI(){
		Social.ShowAchievementsUI ();
	}

	#endregion /Archievements

	#region Leaderboards
	public static void AddScoreToLeaderboard(string leaderboardId, long score){
		if (Social.localUser.authenticated) {
			Social.ReportScore (score, leaderboardId, success => {});
		}else{
			Social.localUser.Authenticate((bool success) => {
				if(success){
					Social.ReportScore (score, leaderboardId, (bool scoreSuccess) => {
						// handle success or failure
					});
				}
			});
		}
	}
	public static void ShowLeaderBoardUI(){
		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowLeaderboardUI (GPGSIds.leaderboard_clasificacion);
		}else{
			Social.localUser.Authenticate((bool success) => {
				if(success){
					PlayGamesPlatform.Instance.ShowLeaderboardUI (GPGSIds.leaderboard_clasificacion);
				}
			});
		}
	}

	public static void GetScore(){
		PlayGamesPlatform.Instance.LoadScores(
			GPGSIds.leaderboard_clasificacion,
			LeaderboardStart.PlayerCentered,
			100,
			LeaderboardCollection.Public,
			LeaderboardTimeSpan.AllTime,
			(data) =>
			{
				string mStatus = "Leaderboard data valid: " + data.Valid;
				mStatus += "\n approx:" +data.ApproximateCount + " have " + data.Scores.Length;
				Debug.Log(mStatus);
			});
	}

	#endregion /Leaderboards

}
*/
