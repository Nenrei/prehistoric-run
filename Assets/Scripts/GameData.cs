
public class GameData {

	public static bool musicEnabled = true;
	public static bool effectsEnabled = true;

	public static int fartCount = 0;
	public static int roarCount = 0;
	public static int humanCount = 0;
	public static int extintionCount = 0;
	public static int level = 1;
	public static int time = 0;

	public static int usedFarts = 0;
	public static int usedRoars = 0;
	public static int usedExtintions = 0;
	public static int humansEated = 0;


	public static int fartPrice = 10;
	public static int roarPrice = 5;
	public static int extintionPrice = 30;

	public static void InitValues(){
		fartCount = 0;
		roarCount = 0;
		humanCount = 0;
		extintionCount = 0;
		level = 1;
		time = 0;

		usedRoars = 0;
		usedExtintions = 0;
		usedFarts = 0;
		humansEated = 0;

	}

}
